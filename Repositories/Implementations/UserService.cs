using Microsoft.EntityFrameworkCore;

namespace OIT_Startup_API.Repositories.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;

        public UserService(ApplicationDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            var users = await _context.Users
                .Include(u => u.UserGroups)
                    .ThenInclude(usg => usg.Group)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToListAsync();

            var userDtos = new List<UserDto>();
            foreach (var user in users)
            {
                var permissions = await _authService.GetUserPermissionsAsync(user.Id);
                userDtos.Add(MapToUserDto(user, permissions));
            }

            return userDtos;
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _context.Users
                .Include(u => u.UserGroups)
                    .ThenInclude(usg => usg.Group)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null) return null;

            var permissions = await _authService.GetUserPermissionsAsync(user.Id);
            return MapToUserDto(user, permissions);
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto dto)
        {
            // Verifica se username o email esistono già
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == dto.Username || u.Email == dto.Email);

            if (existingUser != null)
            {
                throw new InvalidOperationException("Username o email già esistenti");
            }

            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Username = dto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                IsActive = dto.IsActive,
                EmailConfirmed = dto.EmailConfirmed
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Assegna i gruppi di sicurezza
            if (dto.GroupIds?.Any() == true)
            {
                await AssignGroupsAsync(user.Id, dto.GroupIds);
            }

            return await GetUserByIdAsync(user.Id) ?? throw new InvalidOperationException("Errore durante la creazione dell'utente");
        }

        public async Task<UserDto?> UpdateUserAsync(int id, UpdateUserDto dto)
        {
            var user = await _context.Users
                .Include(u => u.UserGroups)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null) return null;

            // Verifica unicità di username/email se vengono modificati
            if (!string.IsNullOrEmpty(dto.Username) && dto.Username != user.Username)
            {
                var existingUsername = await _context.Users
                    .AnyAsync(u => u.Username == dto.Username && u.Id != id);
                if (existingUsername)
                    throw new InvalidOperationException("Username già esistente");
            }

            if (!string.IsNullOrEmpty(dto.Email) && dto.Email != user.Email)
            {
                var existingEmail = await _context.Users
                    .AnyAsync(u => u.Email == dto.Email && u.Id != id);
                if (existingEmail)
                    throw new InvalidOperationException("Email già esistente");
            }

            // Aggiorna i campi
            if (!string.IsNullOrEmpty(dto.FirstName)) user.FirstName = dto.FirstName;
            if (!string.IsNullOrEmpty(dto.LastName)) user.LastName = dto.LastName;
            if (!string.IsNullOrEmpty(dto.Email)) user.Email = dto.Email;
            if (!string.IsNullOrEmpty(dto.Username)) user.Username = dto.Username;
            if (dto.IsActive.HasValue) user.IsActive = dto.IsActive.Value;
            if (dto.EmailConfirmed.HasValue) user.EmailConfirmed = dto.EmailConfirmed.Value;

            await _context.SaveChangesAsync();

            // Aggiorna i gruppi di sicurezza se specificati
            if (dto.GroupIds != null)
            {
                await AssignGroupsAsync(user.Id, dto.GroupIds);
            }

            return await GetUserByIdAsync(user.Id);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            // Non permettere l'eliminazione dell'admin di sistema
            if (user.Id == 1)
            {
                throw new InvalidOperationException("Impossibile eliminare l'amministratore di sistema");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ChangePasswordAsync(int userId, ChangePasswordDto dto)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            if (!BCrypt.Net.BCrypt.Verify(dto.CurrentPassword, user.PasswordHash))
            {
                throw new InvalidOperationException("Password attuale non corretta");
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ResetPasswordAsync(int userId, string newPassword)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AssignGroupsAsync(int userId, List<int> groupIds)
        {
            var user = await _context.Users
                .Include(u => u.UserGroups)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null) return false;

            // Rimuovi tutte le assegnazioni correnti
            _context.UserGroups.RemoveRange(user.UserGroups);

            // Aggiungi le nuove assegnazioni
            foreach (var groupId in groupIds.Distinct())
            {
                var groupExists = await _context.Groups
                    .AnyAsync(sg => sg.Id == groupId && sg.IsActive);

                if (groupExists)
                {
                    user.UserGroups.Add(new UserGroup
                    {
                        UserId = userId,
                        GroupId = groupId
                    });
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }

        private UserDto MapToUserDto(User user, List<string> permissions)
        {
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.Username,
                FullName = user.FullName,
                IsActive = user.IsActive,
                EmailConfirmed = user.EmailConfirmed,
                LastLoginAt = user.LastLoginAt,
                CreatedAt = user.CreatedAt,
                Groups = user.UserGroups.Select(usg => new GroupDto
                {
                    Id = usg.Group.Id,
                    Name = usg.Group.Name,
                    Description = usg.Group.Description,
                    IsActive = usg.Group.IsActive,
                    IsSystemGroup = usg.Group.IsSystemGroup
                }).ToList(),
                Permissions = permissions
            };
        }
    }
}

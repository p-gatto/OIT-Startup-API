using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace OIT_Startup_API.Repositories.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IJwtService _jwtService;
        private readonly IConfiguration _configuration;

        public AuthService(ApplicationDbContext context, IJwtService jwtService, IConfiguration configuration)
        {
            _context = context;
            _jwtService = jwtService;
            _configuration = configuration;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            var user = await _context.Users
                .Include(u => u.UserGroups)
                    .ThenInclude(usg => usg.Group)
                        .ThenInclude(sg => sg.GroupPermissions)
                            .ThenInclude(sgp => sgp.Permission)
                .FirstOrDefaultAsync(u => u.Username == request.Username && u.IsActive);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Credenziali non valide");
            }

            // Ottieni tutti i permessi dell'utente
            var permissions = await GetUserPermissionsAsync(user.Id);

            // Genera i token
            var accessToken = _jwtService.GenerateAccessToken(user, permissions);
            var refreshToken = _jwtService.GenerateRefreshToken();

            // Salva il refresh token
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(int.Parse(_configuration["Jwt:RefreshTokenExpirationDays"] ?? "7"));
            user.LastLoginAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new LoginResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresAt = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:AccessTokenExpirationMinutes"] ?? "60")),
                User = MapToUserDto(user, permissions)
            };
        }

        public async Task<LoginResponseDto> RefreshTokenAsync(string refreshToken)
        {
            var user = await _context.Users
                .Include(u => u.UserGroups)
                    .ThenInclude(usg => usg.Group)
                        .ThenInclude(sg => sg.GroupPermissions)
                            .ThenInclude(sgp => sgp.Permission)
                .FirstOrDefaultAsync(u => u.RefreshToken == refreshToken && u.IsActive);

            if (user == null || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                throw new UnauthorizedAccessException("Refresh token non valido o scaduto");
            }

            var permissions = await GetUserPermissionsAsync(user.Id);
            var newAccessToken = _jwtService.GenerateAccessToken(user, permissions);
            var newRefreshToken = _jwtService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(int.Parse(_configuration["Jwt:RefreshTokenExpirationDays"] ?? "7"));

            await _context.SaveChangesAsync();

            return new LoginResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
                ExpiresAt = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:AccessTokenExpirationMinutes"] ?? "60")),
                User = MapToUserDto(user, permissions)
            };
        }

        public async Task<bool> LogoutAsync(string refreshToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user != null)
            {
                user.RefreshToken = null;
                user.RefreshTokenExpiryTime = null;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<UserDto> GetCurrentUserAsync(ClaimsPrincipal principal)
        {
            var userIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                throw new UnauthorizedAccessException("Token non valido");
            }

            var user = await _context.Users
                .Include(u => u.UserGroups)
                    .ThenInclude(usg => usg.Group)
                        .ThenInclude(sg => sg.GroupPermissions)
                            .ThenInclude(sgp => sgp.Permission)
                .FirstOrDefaultAsync(u => u.Id == userId && u.IsActive);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Utente non trovato");
            }

            var permissions = await GetUserPermissionsAsync(user.Id);
            return MapToUserDto(user, permissions);
        }

        public async Task<bool> HasPermissionAsync(int userId, string resource, string action)
        {
            var hasPermission = await _context.Users
                .Where(u => u.Id == userId && u.IsActive)
                .SelectMany(u => u.UserGroups)
                .Where(usg => usg.Group.IsActive)
                .SelectMany(usg => usg.Group.GroupPermissions)
                .Any(sgp => sgp.Permission.Resource == resource &&
                           sgp.Permission.Action == action &&
                           sgp.Permission.IsActive);

            return hasPermission;
        }

        public async Task<List<string>> GetUserPermissionsAsync(int userId)
        {
            var permissions = await _context.Users
                .Where(u => u.Id == userId && u.IsActive)
                .SelectMany(u => u.UserGroups)
                .Where(usg => usg.Group.IsActive)
                .SelectMany(usg => usg.Group.GroupPermissions)
                .Where(sgp => sgp.Permission.IsActive)
                .Select(sgp => $"{sgp.Permission.Resource}:{sgp.Permission.Action}")
                .Distinct()
                .ToListAsync();

            return permissions;
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

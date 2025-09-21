using Microsoft.EntityFrameworkCore;

namespace OIT_Startup_API.Repositories.Implementations
{
    public class GroupService : IGroupService
    {
        private readonly ApplicationDbContext _context;

        public GroupService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GroupDto>> GetGroupsAsync()
        {
            var groups = await _context.Groups
                .Include(sg => sg.GroupPermissions)
                    .ThenInclude(sgp => sgp.Permission)
                .Include(sg => sg.UserGroups)
                .OrderBy(sg => sg.Name)
                .ToListAsync();

            return groups.Select(MapToGroupDto).ToList();
        }

        public async Task<GroupDto?> GetGroupByIdAsync(int id)
        {
            var group = await _context.Groups
                .Include(sg => sg.GroupPermissions)
                    .ThenInclude(sgp => sgp.Permission)
                .Include(sg => sg.UserGroups)
                .FirstOrDefaultAsync(sg => sg.Id == id);

            return group != null ? MapToGroupDto(group) : null;
        }

        public async Task<GroupDto> CreateGroupAsync(CreateGroupDto dto)
        {
            // Verifica se il nome esiste già
            var existingGroup = await _context.Groups
                .FirstOrDefaultAsync(sg => sg.Name == dto.Name);

            if (existingGroup != null)
            {
                throw new InvalidOperationException("Nome gruppo già esistente");
            }

            var group = new Group
            {
                Name = dto.Name,
                Description = dto.Description,
                IsActive = dto.IsActive,
                IsSystemGroup = false
            };

            _context.Groups.Add(group);
            await _context.SaveChangesAsync();

            // Assegna i permessi
            if (dto.PermissionIds?.Any() == true)
            {
                await AssignPermissionsToGroupAsync(group.Id, dto.PermissionIds);
            }

            return await GetGroupByIdAsync(group.Id) ??
                   throw new InvalidOperationException("Errore durante la creazione del gruppo");
        }

        public async Task<GroupDto?> UpdateGroupAsync(int id, UpdateGroupDto dto)
        {
            var group = await _context.Groups
                .Include(sg => sg.GroupPermissions)
                .FirstOrDefaultAsync(sg => sg.Id == id);

            if (group == null) return null;

            // Non permettere la modifica dei gruppi di sistema
            if (group.IsSystemGroup && !string.IsNullOrEmpty(dto.Name) && dto.Name != group.Name)
            {
                throw new InvalidOperationException("Impossibile modificare il nome di un gruppo di sistema");
            }

            // Verifica unicità del nome se viene modificato
            if (!string.IsNullOrEmpty(dto.Name) && dto.Name != group.Name)
            {
                var existingGroup = await _context.Groups
                    .AnyAsync(sg => sg.Name == dto.Name && sg.Id != id);
                if (existingGroup)
                    throw new InvalidOperationException("Nome gruppo già esistente");
            }

            // Aggiorna i campi
            if (!string.IsNullOrEmpty(dto.Name)) group.Name = dto.Name;
            if (dto.Description != null) group.Description = dto.Description;
            if (dto.IsActive.HasValue) group.IsActive = dto.IsActive.Value;

            await _context.SaveChangesAsync();

            // Aggiorna i permessi se specificati
            if (dto.PermissionIds != null)
            {
                await AssignPermissionsToGroupAsync(group.Id, dto.PermissionIds);
            }

            return await GetGroupByIdAsync(group.Id);
        }

        public async Task<bool> DeleteGroupAsync(int id)
        {
            var group = await _context.Groups
                .Include(sg => sg.UserGroups)
                .FirstOrDefaultAsync(sg => sg.Id == id);

            if (group == null) return false;

            // Non permettere l'eliminazione dei gruppi di sistema
            if (group.IsSystemGroup)
            {
                throw new InvalidOperationException("Impossibile eliminare un gruppo di sistema");
            }

            // Verifica se ci sono utenti assegnati
            if (group.UserGroups.Any())
            {
                throw new InvalidOperationException("Impossibile eliminare un gruppo con utenti assegnati");
            }

            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<PermissionDto>> GetPermissionsAsync()
        {
            var permissions = await _context.Permissions
                .OrderBy(p => p.Resource)
                .ThenBy(p => p.Action)
                .ToListAsync();

            return permissions.Select(MapToPermissionDto).ToList();
        }

        public async Task<PermissionDto> CreatePermissionAsync(CreatePermissionDto dto)
        {
            // Verifica se la combinazione Resource/Action esiste già
            var existingPermission = await _context.Permissions
                .FirstOrDefaultAsync(p => p.Resource == dto.Resource && p.Action == dto.Action);

            if (existingPermission != null)
            {
                throw new InvalidOperationException("Permesso già esistente per questa risorsa e azione");
            }

            var permission = new Permission
            {
                Name = dto.Name,
                Description = dto.Description,
                Resource = dto.Resource,
                Action = dto.Action,
                IsActive = dto.IsActive
            };

            _context.Permissions.Add(permission);
            await _context.SaveChangesAsync();

            return MapToPermissionDto(permission);
        }

        public async Task<bool> DeletePermissionAsync(int id)
        {
            var permission = await _context.Permissions
                .Include(p => p.GroupPermissions)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (permission == null) return false;

            // Verifica se il permesso è assegnato a qualche gruppo
            if (permission.GroupPermissions.Any())
            {
                throw new InvalidOperationException("Impossibile eliminare un permesso assegnato a gruppi di sicurezza");
            }

            _context.Permissions.Remove(permission);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AssignPermissionsToGroupAsync(int groupId, List<int> permissionIds)
        {
            var group = await _context.Groups
                .Include(sg => sg.GroupPermissions)
                .FirstOrDefaultAsync(sg => sg.Id == groupId);

            if (group == null) return false;

            // Rimuovi tutte le assegnazioni correnti
            _context.GroupPermissions.RemoveRange(group.GroupPermissions);

            // Aggiungi le nuove assegnazioni
            foreach (var permissionId in permissionIds.Distinct())
            {
                var permissionExists = await _context.Permissions
                    .AnyAsync(p => p.Id == permissionId && p.IsActive);

                if (permissionExists)
                {
                    group.GroupPermissions.Add(new GroupPermission
                    {
                        GroupId = groupId,
                        PermissionId = permissionId
                    });
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }

        private GroupDto MapToGroupDto(Group group)
        {
            return new GroupDto
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description,
                IsActive = group.IsActive,
                IsSystemGroup = group.IsSystemGroup,
                UserCount = group.UserGroups.Count,
                CreatedAt = group.CreatedAt,
                Permissions = group.GroupPermissions
                    .Select(sgp => MapToPermissionDto(sgp.Permission))
                    .ToList()
            };
        }

        private PermissionDto MapToPermissionDto(Permission permission)
        {
            return new PermissionDto
            {
                Id = permission.Id,
                Name = permission.Name,
                Description = permission.Description,
                Resource = permission.Resource,
                Action = permission.Action,
                IsActive = permission.IsActive,
                CreatedAt = permission.CreatedAt
            };
        }
    }
}

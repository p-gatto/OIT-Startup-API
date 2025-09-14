using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace OIT_Startup_API.Repositories.Implementations
{
    public class MenuService : IMenuService
    {
        private readonly ApplicationDbContext _context;

        public MenuService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MenuGroupDto>> GetMenuStructureAsync()
        {
            var groups = await _context.MenuGroups
                .Where(g => g.IsActive)
                .OrderBy(g => g.Order)
                .Include(g => g.Items.Where(i => i.IsActive))
                .ToListAsync();

            var result = new List<MenuGroupDto>();

            foreach (var group in groups)
            {
                var groupDto = new MenuGroupDto
                {
                    Id = group.Id,
                    Title = group.Title,
                    Order = group.Order,
                    IsActive = group.IsActive,
                    Items = await BuildMenuItemHierarchy(group.Items.Where(i => i.ParentId == null).OrderBy(i => i.Order).ToList())
                };

                result.Add(groupDto);
            }

            return result;
        }

        private async Task<List<MenuItemDto>> BuildMenuItemHierarchy(List<MenuItem> items)
        {
            var result = new List<MenuItemDto>();

            foreach (var item in items)
            {
                var itemDto = new MenuItemDto
                {
                    Id = item.Id,
                    Title = item.Title,
                    Icon = item.Icon,
                    Route = item.Route,
                    QueryParams = ParseQueryParams(item.QueryParams),
                    Order = item.Order,
                    IsActive = item.IsActive,
                    ParentId = item.ParentId
                };

                // Carica i children se esistono
                var children = await _context.MenuItems
                    .Where(i => i.ParentId == item.Id && i.IsActive)
                    .OrderBy(i => i.Order)
                    .ToListAsync();

                if (children.Any())
                {
                    itemDto.Children = await BuildMenuItemHierarchy(children);
                }

                result.Add(itemDto);
            }

            return result;
        }

        private Dictionary<string, object>? ParseQueryParams(string? queryParamsJson)
        {
            if (string.IsNullOrEmpty(queryParamsJson) || queryParamsJson == "{}")
                return new Dictionary<string, object>();

            try
            {
                return JsonSerializer.Deserialize<Dictionary<string, object>>(queryParamsJson);
            }
            catch
            {
                return new Dictionary<string, object>();
            }
        }

        public async Task<MenuGroupDto?> GetMenuGroupAsync(int id)
        {
            var group = await _context.MenuGroups
                .Include(g => g.Items)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (group == null) return null;

            return new MenuGroupDto
            {
                Id = group.Id,
                Title = group.Title,
                Order = group.Order,
                IsActive = group.IsActive,
                Items = await BuildMenuItemHierarchy(group.Items.Where(i => i.ParentId == null).OrderBy(i => i.Order).ToList())
            };
        }

        public async Task<MenuItemDto?> GetMenuItemAsync(int id)
        {
            var item = await _context.MenuItems.FindAsync(id);
            if (item == null) return null;

            return new MenuItemDto
            {
                Id = item.Id,
                Title = item.Title,
                Icon = item.Icon,
                Route = item.Route,
                QueryParams = ParseQueryParams(item.QueryParams),
                Order = item.Order,
                IsActive = item.IsActive,
                ParentId = item.ParentId
            };
        }

        public async Task<MenuGroupDto> CreateMenuGroupAsync(CreateMenuGroupDto dto)
        {
            var group = new MenuGroup
            {
                Title = dto.Title,
                Order = dto.Order,
                IsActive = dto.IsActive
            };

            _context.MenuGroups.Add(group);
            await _context.SaveChangesAsync();

            return new MenuGroupDto
            {
                Id = group.Id,
                Title = group.Title,
                Order = group.Order,
                IsActive = group.IsActive,
                Items = new List<MenuItemDto>()
            };
        }

        public async Task<MenuItemDto> CreateMenuItemAsync(CreateMenuItemDto dto)
        {
            var item = new MenuItem
            {
                Title = dto.Title,
                Icon = dto.Icon,
                Route = dto.Route,
                QueryParams = dto.QueryParams != null ? JsonSerializer.Serialize(dto.QueryParams) : "{}",
                Order = dto.Order,
                IsActive = dto.IsActive,
                ParentId = dto.ParentId,
                MenuGroupId = dto.MenuGroupId
            };

            _context.MenuItems.Add(item);
            await _context.SaveChangesAsync();

            return new MenuItemDto
            {
                Id = item.Id,
                Title = item.Title,
                Icon = item.Icon,
                Route = item.Route,
                QueryParams = dto.QueryParams,
                Order = item.Order,
                IsActive = item.IsActive,
                ParentId = item.ParentId
            };
        }

        public async Task<MenuGroupDto?> UpdateMenuGroupAsync(int id, CreateMenuGroupDto dto)
        {
            var group = await _context.MenuGroups.FindAsync(id);
            if (group == null) return null;

            group.Title = dto.Title;
            group.Order = dto.Order;
            group.IsActive = dto.IsActive;

            await _context.SaveChangesAsync();

            return await GetMenuGroupAsync(id);
        }

        public async Task<MenuItemDto?> UpdateMenuItemAsync(int id, UpdateMenuItemDto dto)
        {
            var item = await _context.MenuItems.FindAsync(id);
            if (item == null) return null;

            if (dto.Title != null) item.Title = dto.Title;
            if (dto.Icon != null) item.Icon = dto.Icon;
            if (dto.Route != null) item.Route = dto.Route;
            if (dto.QueryParams != null) item.QueryParams = JsonSerializer.Serialize(dto.QueryParams);
            if (dto.Order.HasValue) item.Order = dto.Order.Value;
            if (dto.IsActive.HasValue) item.IsActive = dto.IsActive.Value;
            if (dto.ParentId.HasValue) item.ParentId = dto.ParentId.Value;

            await _context.SaveChangesAsync();

            return await GetMenuItemAsync(id);
        }

        public async Task<bool> DeleteMenuGroupAsync(int id)
        {
            var group = await _context.MenuGroups.FindAsync(id);
            if (group == null) return false;

            _context.MenuGroups.Remove(group);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMenuItemAsync(int id)
        {
            var item = await _context.MenuItems.FindAsync(id);
            if (item == null) return false;

            _context.MenuItems.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ReorderMenuGroupsAsync(Dictionary<int, int> orderMap)
        {
            foreach (var kvp in orderMap)
            {
                var group = await _context.MenuGroups.FindAsync(kvp.Key);
                if (group != null)
                {
                    group.Order = kvp.Value;
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ReorderMenuItemsAsync(Dictionary<int, int> orderMap)
        {
            foreach (var kvp in orderMap)
            {
                var item = await _context.MenuItems.FindAsync(kvp.Key);
                if (item != null)
                {
                    item.Order = kvp.Value;
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }

}
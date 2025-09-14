namespace OIT_Startup_API.Repositories.Interfaces
{
    public interface IMenuService
    {
        Task<List<MenuGroupDto>> GetMenuStructureAsync();
        Task<MenuGroupDto?> GetMenuGroupAsync(int id);
        Task<MenuItemDto?> GetMenuItemAsync(int id);
        Task<MenuGroupDto> CreateMenuGroupAsync(CreateMenuGroupDto dto);
        Task<MenuItemDto> CreateMenuItemAsync(CreateMenuItemDto dto);
        Task<MenuGroupDto?> UpdateMenuGroupAsync(int id, CreateMenuGroupDto dto);
        Task<MenuItemDto?> UpdateMenuItemAsync(int id, UpdateMenuItemDto dto);
        Task<bool> DeleteMenuGroupAsync(int id);
        Task<bool> DeleteMenuItemAsync(int id);
        Task<bool> ReorderMenuGroupsAsync(Dictionary<int, int> orderMap);
        Task<bool> ReorderMenuItemsAsync(Dictionary<int, int> orderMap);
    }
}

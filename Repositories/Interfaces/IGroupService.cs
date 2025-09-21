namespace OIT_Startup_API.Repositories.Interfaces
{
    public interface IGroupService
    {
        Task<List<GroupDto>> GetGroupsAsync();
        Task<GroupDto?> GetGroupByIdAsync(int id);
        Task<GroupDto> CreateGroupAsync(CreateGroupDto dto);
        Task<GroupDto?> UpdateGroupAsync(int id, UpdateGroupDto dto);
        Task<bool> DeleteGroupAsync(int id);
        Task<List<PermissionDto>> GetPermissionsAsync();
        Task<PermissionDto> CreatePermissionAsync(CreatePermissionDto dto);
        Task<bool> DeletePermissionAsync(int id);
        Task<bool> AssignPermissionsToGroupAsync(int groupId, List<int> permissionIds);
    }
}

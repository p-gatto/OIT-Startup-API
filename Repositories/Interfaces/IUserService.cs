namespace OIT_Startup_API.Repositories.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUsersAsync();
        Task<UserDto?> GetUserByIdAsync(int id);
        Task<UserDto> CreateUserAsync(CreateUserDto dto);
        Task<UserDto?> UpdateUserAsync(int id, UpdateUserDto dto);
        Task<bool> DeleteUserAsync(int id);
        Task<bool> ChangePasswordAsync(int userId, ChangePasswordDto dto);
        Task<bool> ResetPasswordAsync(int userId, string newPassword);
        Task<bool> AssignGroupsAsync(int userId, List<int> groupIds);
    }
}

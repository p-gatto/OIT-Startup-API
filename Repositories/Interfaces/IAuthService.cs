using System.Security.Claims;

namespace OIT_Startup_API.Repositories.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
        Task<LoginResponseDto> RefreshTokenAsync(string refreshToken);
        Task<bool> LogoutAsync(string refreshToken);
        Task<UserDto> GetCurrentUserAsync(ClaimsPrincipal principal);
        Task<bool> HasPermissionAsync(int userId, string resource, string action);
        Task<List<string>> GetUserPermissionsAsync(int userId);
    }
}
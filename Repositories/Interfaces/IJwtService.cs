using System.Security.Claims;

namespace OIT_Startup_API.Repositories.Interfaces
{
    public interface IJwtService
    {
        string GenerateAccessToken(User user, List<string> permissions);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
        bool ValidateToken(string token);
    }
}

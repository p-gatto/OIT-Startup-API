using System.ComponentModel.DataAnnotations;

namespace OIT_Startup_API.Models.Dtos.Auth
{
    public class RefreshTokenRequestDto
    {
        [Required]
        public string RefreshToken { get; set; } = string.Empty;
    }
}

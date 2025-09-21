using System.ComponentModel.DataAnnotations;

namespace OIT_Startup_API.Models.Dtos.Auth
{
    public class CreatePermissionDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(100)]
        public string Resource { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Action { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}

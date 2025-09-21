using System.ComponentModel.DataAnnotations;

namespace OIT_Startup_API.Models.Dtos.Auth
{
    public class CreateGroupDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public List<int> PermissionIds { get; set; } = new();
    }
}

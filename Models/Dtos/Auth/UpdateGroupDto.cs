using System.ComponentModel.DataAnnotations;

namespace OIT_Startup_API.Models.Dtos.Auth
{
    public class UpdateGroupDto
    {
        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public bool? IsActive { get; set; }

        public List<int>? PermissionIds { get; set; }
    }
}

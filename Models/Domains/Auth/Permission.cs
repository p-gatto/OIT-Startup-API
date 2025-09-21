using System.ComponentModel.DataAnnotations;

namespace OIT_Startup_API.Models.Domains.Auth
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(100)]
        public string Resource { get; set; } = string.Empty; // Es: "Menu", "User", "Report"

        [Required]
        [MaxLength(50)]
        public string Action { get; set; } = string.Empty; // Es: "Create", "Read", "Update", "Delete"

        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual ICollection<GroupPermission> GroupPermissions { get; set; } = new List<GroupPermission>();

        // Audit
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
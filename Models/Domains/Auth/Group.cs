using System.ComponentModel.DataAnnotations;

namespace OIT_Startup_API.Models.Domains.Auth
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsSystemGroup { get; set; } = false; // Per gruppi predefiniti come Admin, User

        // Navigation properties
        public virtual ICollection<UserGroup> UserGroups { get; set; } = new List<UserGroup>();
        public virtual ICollection<GroupPermission> GroupPermissions { get; set; } = new List<GroupPermission>();

        // Audit
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
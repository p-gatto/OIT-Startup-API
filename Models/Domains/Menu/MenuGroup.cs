using System.ComponentModel.DataAnnotations;

namespace OIT_Startup_API.Models.Domains.Menu
{
    public class MenuGroup
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        public int Order { get; set; }

        public bool IsActive { get; set; } = true;

        public virtual ICollection<MenuItem> Items { get; set; } = new List<MenuItem>();

        // Audit
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}

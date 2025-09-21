using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OIT_Startup_API.Models.Domains.Menu
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Icon { get; set; }

        [MaxLength(500)]
        public string? Route { get; set; }

        public string? QueryParams { get; set; } // JSON serialized

        public int Order { get; set; }

        public bool IsActive { get; set; } = true;

        // Gerarchia
        public int? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public MenuItem? Parent { get; set; }

        public virtual ICollection<MenuItem> Children { get; set; } = new List<MenuItem>();

        // Gruppo di appartenenza
        public int MenuGroupId { get; set; }

        [ForeignKey(nameof(MenuGroupId))]
        public MenuGroup MenuGroup { get; set; } = null!;

        // Audit
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}

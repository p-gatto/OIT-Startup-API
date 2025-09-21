using System.ComponentModel.DataAnnotations;

namespace OIT_Startup_API.Models.Dtos.Menu
{
    public class CreateMenuItemDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        public string? Icon { get; set; }
        public string? Route { get; set; }
        public Dictionary<string, object>? QueryParams { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; } = true;
        public int? ParentId { get; set; }
        public int MenuGroupId { get; set; }
    }
}

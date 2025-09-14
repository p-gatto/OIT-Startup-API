namespace OIT_Startup_API.Models.Dtos
{
    public class MenuItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Icon { get; set; }
        public string? Route { get; set; }
        public Dictionary<string, object>? QueryParams { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public int? ParentId { get; set; }
        public List<MenuItemDto>? Children { get; set; }
    }
}

namespace OIT_Startup_API.Models.Dtos.Menu
{
    public class UpdateMenuItemDto
    {
        public string? Title { get; set; }
        public string? Icon { get; set; }
        public string? Route { get; set; }
        public Dictionary<string, object>? QueryParams { get; set; }
        public int? Order { get; set; }
        public bool? IsActive { get; set; }
        public int? ParentId { get; set; }
    }
}

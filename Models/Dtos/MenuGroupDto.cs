namespace OIT_Startup_API.Models.Dtos
{
    public class MenuGroupDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public List<MenuItemDto> Items { get; set; } = new();
    }
}

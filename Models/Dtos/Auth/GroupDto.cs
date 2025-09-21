namespace OIT_Startup_API.Models.Dtos.Auth
{
    public class GroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsSystemGroup { get; set; }
        public int UserCount { get; set; }
        public List<PermissionDto> Permissions { get; set; } = new();
        public DateTime CreatedAt { get; set; }
    }
}

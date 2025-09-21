namespace OIT_Startup_API.Models.Dtos.Auth
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public bool EmailConfirmed { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public List<GroupDto> Groups { get; set; } = new();
        public List<string> Permissions { get; set; } = new();
        public DateTime CreatedAt { get; set; }
    }
}

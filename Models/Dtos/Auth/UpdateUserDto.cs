using System.ComponentModel.DataAnnotations;

namespace OIT_Startup_API.Models.Dtos.Auth
{
    public class UpdateUserDto
    {
        [MaxLength(100)]
        public string? FirstName { get; set; }

        [MaxLength(100)]
        public string? LastName { get; set; }

        [EmailAddress]
        [MaxLength(255)]
        public string? Email { get; set; }

        [MaxLength(20)]
        public string? Username { get; set; }

        public bool? IsActive { get; set; }

        public bool? EmailConfirmed { get; set; }

        public List<int>? GroupIds { get; set; }
    }
}
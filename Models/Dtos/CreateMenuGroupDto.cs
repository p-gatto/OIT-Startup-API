using System.ComponentModel.DataAnnotations;

namespace OIT_Startup_API.Models.Dtos
{
    public class CreateMenuGroupDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        public int Order { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
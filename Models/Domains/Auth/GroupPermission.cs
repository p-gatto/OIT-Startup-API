using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OIT_Startup_API.Models.Domains.Auth
{
    public class GroupPermission
    {
        [Key]
        public int Id { get; set; }

        public int GroupId { get; set; }

        [ForeignKey(nameof(GroupId))]
        public Group Group { get; set; } = null!;

        public int PermissionId { get; set; }

        [ForeignKey(nameof(PermissionId))]
        public Permission Permission { get; set; } = null!;

        public DateTime GrantedAt { get; set; } = DateTime.UtcNow;

        public int? GrantedBy { get; set; } // ID dell'utente che ha concesso il permesso
    }
}
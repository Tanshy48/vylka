#nullable disable
using System.ComponentModel.DataAnnotations;

namespace vylka.Models
{
    public class RoleModification
    {
        [Required(ErrorMessage = "Таких не знаємо")]
        [StringLength(30)]
        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public string[] AddIds { get; set; }
        public string[] DeleteIds { get; set; }
    }
}

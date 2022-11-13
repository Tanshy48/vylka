using Microsoft.AspNetCore.Identity;
using vylka.Areas.Entity;

namespace vylka.Models
{
    public class RoleEdit
    {

        public IdentityRole Role { get; set; }
        public IEnumerable<IdentityUser> Members { get; set; }
        public IEnumerable<IdentityUser> NonMembers { get; set; }
    }
}

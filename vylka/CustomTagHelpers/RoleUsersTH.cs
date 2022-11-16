using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel.DataAnnotations;
using vylka.Areas.Entity;

namespace vylka.CustomTagHelpers
{
    [HtmlTargetElement("td", Attributes = "i-role")]

    public class RoleUsersTH : TagHelper
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public RoleUsersTH(UserManager<IdentityUser> usermgr, RoleManager<IdentityRole> rolemgr)
        {
            _userManager = usermgr;
            _roleManager = rolemgr;
        }

        [HtmlAttributeName("i-role")]
        [Required(ErrorMessage = "Таких не знаємо")]
        [StringLength(30)]
        public string Role { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            List<string> names = new List<string>();
            IdentityRole role = await _roleManager.FindByIdAsync(Role);
            if (role != null)
            {
                foreach (var user in _userManager.Users)
                {
                    if (user != null && await _userManager.IsInRoleAsync(user, role.Name))
                        names.Add(user.UserName);
                }
            }
            output.Content.SetContent(names.Count == 0 ? "No Users" : string.Join(", ", names));
        }
    }
}

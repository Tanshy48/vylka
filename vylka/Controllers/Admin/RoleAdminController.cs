using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using vylka.Data;

namespace vylka.Controllers.Admin
{
    public class RoleAdminController : Controller
    {
        private readonly vylkaContext _db;
        RoleManager<IdentityRole> roleManager;

        public RoleAdminController(vylkaContext db, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            this.roleManager = roleManager;

        }
        public IActionResult Roles()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult AddRole()
        {
            return View(new IdentityRole());
        }

        public async Task<IActionResult> EditRole(string? id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if(role == null)
            {
                return NotFound();
            }
            var model = new IdentityRole
            {
                Id = role.Id,
                Name = role.Name
            };
            return View(model);
        }
        public async Task<IActionResult> DeleteRole(string? id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            var model = new IdentityRole
            {
                Id = role.Id,
                Name = role.Name
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(IdentityRole role)
        {
            await roleManager.CreateAsync(role);
            return RedirectToAction("Roles");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole(IdentityRole model)
        {
            var role = await roleManager.FindByIdAsync(model.Id); 
            if(role == null)
            {
                return NotFound();
            }
            else
            {
                role.Name = model.Name;
                var result = await roleManager.UpdateAsync(role);

                if(result.Succeeded)
                {
                    return RedirectToAction("Roles");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRole(IdentityRole model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                return NotFound();
            }
            else
            {
                var result = await roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Roles");
                }
            }
            return View(model);
        }


    }
}

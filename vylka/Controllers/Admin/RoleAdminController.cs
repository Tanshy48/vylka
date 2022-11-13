using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using vylka.Areas.Entity;
using vylka.Data;
using vylka.Models;

namespace vylka.Controllers.Admin
{
    //[Authorize(Roles = "Admin")]
    public class RoleAdminController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<IdentityUser> userManager;

        public RoleAdminController(RoleManager<IdentityRole> roleMgr, UserManager<IdentityUser> userMrg)
        {
            roleManager = roleMgr;
            userManager = userMrg;
        }
        public IActionResult Roles()
        {
            return View(roleManager.Roles);
        }

        public IActionResult AddRole()
        {
            return View(new IdentityRole());
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
        public async Task<IActionResult> AddRole([Required(ErrorMessage = "Таких не знаємо")] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                    return RedirectToAction("Roles");
            }
            return View(name);
        }
        

        [HttpPost]
        public async Task<IActionResult> DeleteRolePOST(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Roles");
            }
            else
                ModelState.AddModelError("", "No role found");
            return View("Roles", roleManager.Roles);
        }
        
        public async Task<IActionResult> UpdateRole(string id)
        {
            
            IdentityRole role = await roleManager.FindByIdAsync(id);
            List<IdentityUser> members = new List<IdentityUser>();
            List<IdentityUser> nonMembers = new List<IdentityUser>();
            foreach (IdentityUser user in userManager.Users)
            {
                var list = await userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }
            return View(new RoleEdit
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleModification model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.AddIds ?? new string[] { })
                {
                    IdentityUser user = await userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            NotFound(userId);
                    }
                }
                foreach (string userId in model.DeleteIds ?? new string[] { })
                {
                    IdentityUser user = await userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            NotFound(userId);
                    }
                }
            }

            if (ModelState.IsValid)
                return RedirectToAction(nameof(Roles));
            else
                return await UpdateRole(model.RoleId);
        }

    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using vylka.Models;

namespace vylka.Controllers.Admin
{
    /*[Authorize(Roles = "Адмін")]*/
    public class RoleAdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RoleAdminController(RoleManager<IdentityRole> roleMgr, UserManager<IdentityUser> userMrg)
        {
            _roleManager = roleMgr;
            _userManager = userMrg;
        }
        public IActionResult Roles()
        {
            return View(_roleManager.Roles);
        }

        public IActionResult AddRole()
        {
            return View(new IdentityRole());
        }

        public async Task<IActionResult> DeleteRole(string? id)
        {
            var role = await _roleManager.FindByIdAsync(id);
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
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                    return RedirectToAction("Roles");
            }
            return View(name);
        }
        

        [HttpPost]
        public async Task<IActionResult> DeleteRolePost(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Roles");
            }
            else
                ModelState.AddModelError("", "No role found");
            return View("Roles", _roleManager.Roles);
        }
        
        public async Task<IActionResult> UpdateRole(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            List<IdentityUser> members = new List<IdentityUser>();
            List<IdentityUser> nonMembers = new List<IdentityUser>();
            foreach (IdentityUser user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
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
            if (ModelState.IsValid)
            {
                IdentityResult result;
                foreach (string userId in model.AddIds ?? new string[] { })
                {
                    IdentityUser user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await _userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            NotFound(userId);
                    }
                }
                foreach (string userId in model.DeleteIds ?? new string[] { })
                {
                    IdentityUser user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
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

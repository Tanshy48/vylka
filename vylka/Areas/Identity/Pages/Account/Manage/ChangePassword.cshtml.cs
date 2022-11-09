#nullable disable

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using vylka.Areas.Entity;
using vylka.Models;

namespace vylka.Areas.Identity.Pages.Account.Manage
{
    public class ChangePasswordModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<ChangePasswordModel> _logger;

        public ChangePasswordModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<ChangePasswordModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
           
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Старий пароль")]
            public string OldPassword { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "{0} повинен містити щонайменше {2} та не більше {1} символів.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Новий пароль")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Повторіть новий пароль")]
            [Compare("NewPassword", ErrorMessage = "Паролі не співпадають.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Неможливо знайти користувача з ID: '{_userManager.GetUserId(User)}'.");
            }

            var hasPassword = await _userManager.HasPasswordAsync(user);
            if (!hasPassword)
            {
                return RedirectToPage("./SetPassword");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Неможливо знайти користувача з ID: '{_userManager.GetUserId(User)}'.");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, Input.OldPassword, Input.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }

            await _signInManager.RefreshSignInAsync(user);
            _logger.LogInformation("Користувач успішно змінив пароль.");
            StatusMessage = "Ваш пароль було змінено.";

            return RedirectToPage();
        }
    }
}

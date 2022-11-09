#nullable disable

using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using vylka.Areas.Entity;
using vylka.Models;

namespace vylka.Areas.Identity.Pages.Account
{
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<User> _userManager;

        public ConfirmEmailModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [TempData]
        public string StatusMessage { get; set; }
        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Неможливо знайти користувача з ID: '{userId}'.");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            StatusMessage = result.Succeeded ? "Дякуємо, за підтвердження вашої електронної скриньки." : "Помилка під час підтвердження електронної скриньки.";

            // після підтвердження перехід на головну
            return RedirectToPage("/Account/Login", new { area = "Identity" });
          //  return RedirectToPage("/Account/Login");
            //повертає ту ж сторінку з підтвердженням
            //return Page();
        }
    }
}

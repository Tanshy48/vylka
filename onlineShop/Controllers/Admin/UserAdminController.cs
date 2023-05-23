#nullable disable

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using onlineShop.Areas.Identity.Data;

namespace onlineShop.Controllers.Admin
{
    [Authorize(Roles = "Адмін")]
    public class UserAdminController : Controller
    {
        private readonly OnlineShopContext _context;
        public UserAdminController(OnlineShopContext context)
        {
            _context = context;
        }
        
        public ActionResult Users()
        {
           return View(_context.Users.ToList());
        }
        [HttpGet]
        public ActionResult DeleteUser(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userFromDb = _context.Users.Find(id);
            if (userFromDb == null)
            {
                return NotFound();
            }
            return View(userFromDb);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteUserPost(string id)
        {
            var obj = _context.Users.Find(id);
            var cart = _context.Cart.OrderBy(o => o.Id).LastOrDefault(u => u.CartUserId.Id == id);

            if (obj == null || cart == null)
            {
                return NotFound();
            }

            foreach (var item in _context.ShippingDetail.Where(u => u.UserId == id)) _context.ShippingDetail.Remove(item);

            _context.Cart.Remove(cart);
            _context.Users.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Users");
        }

    }
}

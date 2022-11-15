#nullable disable

using Microsoft.AspNetCore.Mvc;
using vylka.Data;

namespace vylka.Controllers.Admin
{
    //[Authorize(Roles = "Admin")]
    public class UserAdminController : Controller
    {
        private readonly vylkaContext _context;
        public UserAdminController(vylkaContext context)
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
            var UserFromDb = _context.Users.Find(id);
            if (UserFromDb == null)
            {
                return NotFound();
            }
            return View(UserFromDb);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteUserPOST(string id)
        {
            var obj = _context.Users.Find(id);
            var cart = _context.Cart.OrderBy(o => o.Id).LastOrDefault(u => u.CartUserId.Id == id);
            if (obj == null || cart == null)
            {
                return NotFound();
            }

            _context.Cart.Remove(cart);
            _context.Users.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Users");
        }

    }
}

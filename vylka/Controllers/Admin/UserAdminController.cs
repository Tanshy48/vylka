#nullable disable

using Microsoft.AspNetCore.Mvc;
using vylka.Areas.Entity;
using vylka.Areas.Identity.Data;

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
            var items = _context.ShippingDetail.Where(u => u.UserId.Id == id);
            
            if (obj == null || cart == null)
            {
                return NotFound();
            }

            if (items != null)
            {
                foreach (var item in _context.ShippingDetail.Where(u => u.UserId.Id == id))
                {
                    _context.ShippingDetail.Remove(item);
                }
            }
            
            _context.Cart.Remove(cart);
            _context.Users.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Users");
        }

    }
}

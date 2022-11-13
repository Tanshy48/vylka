using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vylka.Data;

namespace Fork_Site.Controllers
{
    /* [Authorize(Roles = "Admin")] */
    public class OrderAdminController : Controller
    {
        private readonly vylkaContext _context;

        public OrderAdminController(vylkaContext context)
        {
            _context = context;
        }

        public ActionResult Orders()
        {
            return View(_context.CartItem.ToList());
        }
        public ActionResult DeleteOrder(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var OrderFromDb = _context.CartItem.Find(id);
            if (OrderFromDb == null)
            {
                return NotFound();
            }
            return View(OrderFromDb);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteOrderPOST(int? id)
        {
            var obj = _context.CartItem.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _context.CartItem.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Orders");
        }
        
    }
}

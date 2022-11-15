using Microsoft.AspNetCore.Mvc;
using vylka.Data;

namespace vylka.Controllers.Admin
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
            return View(_context.ShippingDetail.ToList());
        }
        public ActionResult DeleteOrder(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var OrderFromDb = _context.ShippingDetail.Find(id);
            if (OrderFromDb == null)
            {
                return NotFound();
            }
            return RedirectToAction("Orders");
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

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vylka.Areas.Identity.Data;

namespace vylka.Controllers.Admin
{
    [Authorize(Roles = "Адмін")]
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
            var orderFromDb = _context.ShippingDetail.Find(id);
            if (orderFromDb == null)
            {
                return NotFound();
            }
            return View(orderFromDb);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteOrderPost(int? id)
        {
            var orderFromDb = _context.ShippingDetail.Find(id);
            if (orderFromDb == null)
            {
                return NotFound();
            }
            _context.ShippingDetail.Remove(orderFromDb);
            _context.SaveChanges();
            return RedirectToAction("Orders");
        }
        
    }
}

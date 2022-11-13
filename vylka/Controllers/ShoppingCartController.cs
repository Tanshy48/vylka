using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vylka.Areas.Entity;
using vylka.Data;

namespace vylka.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly vylkaContext _context;

        public ShoppingCartController(vylkaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var delivery = GetDelivery();

            if (delivery == null || delivery.IsActive == false)
            {
                return RedirectToAction("Index", "Home");
            }
            
            //Все продукты из корзины ю
            
            var items = _context.CartItem.Select(s => s).Where(w => w.CartId == delivery.Id);

            return View(items);
        }


        private Cart GetDelivery()
        {
            var currentUser = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

            if (currentUser == null)
            {
                currentUser = _context.Users.FirstOrDefault(u => u.Id == currentUser.Id);
            }

            return _context.Cart.OrderBy(o => o.Id).LastOrDefault(u => u.CartUserId == currentUser);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vylka.Data;

namespace vylka.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly vylkaContext _db;

        public IActionResult Index()
        {
            var items = _db.CartItem.Include(s => s.Product).ToList();
            return View(items);
        }
    }
}
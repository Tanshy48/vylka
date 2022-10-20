using Microsoft.AspNetCore.Mvc;

namespace vylka.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
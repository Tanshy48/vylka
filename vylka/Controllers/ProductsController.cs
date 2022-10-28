using Microsoft.AspNetCore.Mvc;

namespace vylka.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Refrigerators()
        {
            return View();
        }
        public IActionResult TVs()
        {
            return View();
        }
        public IActionResult Vacuums()
        {
            return View();
        }
        public IActionResult Conditioners()
        {
            return View();
        }
    }
}
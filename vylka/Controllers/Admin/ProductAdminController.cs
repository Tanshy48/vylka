using Microsoft.AspNetCore.Mvc;

namespace Fork_Site.Controllers
{
    public class ProductAdminController : Controller
    {
        public ActionResult Products()
        {
            return View();
        }
        public ActionResult AddProduct()
        {
            return View();
        }
        public ActionResult EditProduct()
        {
            return View();
        }
        public ActionResult DeleteProduct()
        {
            return View();
        }
    }
}

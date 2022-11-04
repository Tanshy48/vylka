using Microsoft.AspNetCore.Mvc;
using vylka.Data;

namespace Fork_Site.Controllers
{
    public class ProductAdminController : Controller
    {
        private readonly vylkaContext _db;
        public ProductAdminController(vylkaContext db)
        {
            _db = db;
        }
        public ActionResult Products()
        {
            return View(_db.Products.ToList());
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

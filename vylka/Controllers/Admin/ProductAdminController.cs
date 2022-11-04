using Microsoft.AspNetCore.Mvc;
using vylka.Areas.Entity;
using vylka.Data;
using vylka.Models;

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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Products");
            }
            return View(model);
        }
    }
}

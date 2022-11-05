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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProductPOST(ProductModel model)
        {

            if (ModelState.IsValid)
            {
                var p = new Product()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Quantity = model.Quantity,
                    Price = model.Price,
                    CategoryId = model.CategoryId
                };
                _db.Products.Update(p);
                _db.SaveChanges();
                return RedirectToAction("Products");
            }
            return View(model);
        }



        public ActionResult EditProduct(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ProductsFromDb = _db.Products.Find(id);


            if (ProductsFromDb == null)
            {
                return NotFound();
            }

            return View(ProductsFromDb);
        }
        public ActionResult DeleteProduct()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                Product p = new Product()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Quantity = model.Quantity,
                    Price = model.Price,
                    CategoryId = model.CategoryId
                };
                _db.Products.Add(p);
                _db.SaveChanges();
                return RedirectToAction("Products");
            }
            return View(model);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vylka.Areas.Entity;
using vylka.Data;
using vylka.Models;

namespace Fork_Site.Controllers
{
    /* [Authorize(Roles = "Admin")] */
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
        public ActionResult EditProduct(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ProductFromDb = _db.Products.Find(id);
            if (ProductFromDb == null)
            {
                return NotFound();
            }
            return View(ProductFromDb);
        }
        public ActionResult DeleteProduct(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ProductFromDb = _db.Products.Find(id);
            if (ProductFromDb == null)
            {
                return NotFound();
            }
            return View(ProductFromDb);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProductPOST(int? id)
        {
            var obj = _db.Products.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Products.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Products");
        }
    }
}

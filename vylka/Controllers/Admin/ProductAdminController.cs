using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vylka.Areas.Entity;
using vylka.Areas.Identity.Data;
using vylka.Models;

namespace vylka.Controllers.Admin
{
    /*[Authorize(Roles = "Адмін")]*/
    public class ProductAdminController : Controller
    {
        private readonly vylkaContext _db;
        public ProductAdminController(vylkaContext db)
        {
            _db = db;
        }
        public ActionResult Products()
        {
            return View(_db.Product.ToList());
        }
        public ActionResult AddProduct()
        {
            return View();
        }
        
        public ActionResult EditProduct(int? id)
        {
            Product? productFromDb = _db.Product.Find(id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        public ActionResult DeleteProduct(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var productFromDb = _db.Product.Find(id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
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
                    ProductName = model.ProductName,
                    Description = model.Description,
                    Price = model.Price,
                    CategoryId = model.CategoryId
                };
                _db.Product.Add(p);
                _db.SaveChanges();
                return RedirectToAction("Products");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProductPost(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                Product p = new Product()
                {
                    Id = model.Id,
                    ProductName = model.ProductName,
                    Description = model.Description,
                    Price = model.Price,
                    CategoryId = model.CategoryId
                };
                _db.Product.Update(p);
                _db.SaveChanges();
                
            }
            return RedirectToAction("Products");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProductPost(int? id)
        {
            var obj = _db.Product.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Product.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Products");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using vylka.Areas.Entity;
using vylka.Data;
using vylka.Models;

namespace Fork_Site.Controllers
{
    public class CategoryAdminController : Controller
    {
        private readonly vylkaContext _db;
        public CategoryAdminController(vylkaContext db)
        {
            _db = db;  
        }

        public ActionResult Categories()
        {
            return View(_db.Category.ToList());
        }
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategoryPOST(Category obj)
        {

            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Categories");
            }
            return View(obj);
        }

        public ActionResult EditCategory(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CategoryFromDb = _db.Category.Find(id);


            if (CategoryFromDb == null)
            {
                return NotFound();
            }

            return View(CategoryFromDb);
        }

        public ActionResult DeleteProduct()
        {
            return View();
        }
        public ActionResult DeleteCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(Category model)
        {
            if(ModelState.IsValid)
            {
                _db.Category.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Categories");
            }
            return View(model);
        }
    }
}


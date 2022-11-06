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
        public ActionResult EditCategory(int? id)
        {
            if( id == null || id == 0)
            {
                return NotFound();
            }
            var CategoryFromDb = _db.Category.Find(id);
            if(CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }
        public ActionResult DeleteCategory(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory(Category model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                _db.Category.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Categories");
            }
            catch (Exception)
            {
                return BadRequest();
            }
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategoryPOST(int? id)
        {
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Category.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Categories");
        }
    }
}

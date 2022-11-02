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
        public ActionResult EditCategory()
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

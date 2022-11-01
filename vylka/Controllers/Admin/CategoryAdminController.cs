using Microsoft.AspNetCore.Mvc;
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
            IEnumerable<CategoryModel> CategoryList = _db.Categories;
            return View(CategoryList);
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
        public ActionResult AddCategory(CategoryModel obj)
        {
            if(ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Categories");
            }
            return View(obj);
        }
    }
}

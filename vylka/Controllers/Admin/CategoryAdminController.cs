using Microsoft.AspNetCore.Mvc;
using vylka.Areas.Entity;
using vylka.Areas.Identity.Data;

namespace vylka.Controllers.Admin
{
    /* [Authorize(Roles = "Admin")] */
    public class CategoryAdminController : Controller
    {
        private readonly vylkaContext _context;
        public CategoryAdminController(vylkaContext context)
        {
            _context = context;  
        }

        public ActionResult Categories()
        {
            return View(_context.Category.ToList());
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
            var categoryFromDb = _context.Category.Find(id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        public ActionResult DeleteCategory(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _context.Category.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory(Category model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                _context.Category.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Categories");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategoryPost(Category obj)
        {

            if (ModelState.IsValid)
            {
                _context.Category.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Categories");
            }
            return View("EditCategory");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategoryPost(int? id)
        {
            var obj = _context.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _context.Category.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Categories");
        }
    }
}


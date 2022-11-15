using Microsoft.AspNetCore.Mvc;
using vylka.Areas.Entity;
using vylka.Data;

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
            var CategoryFromDb = _context.Category.Find(id);
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
            var CategoryFromDb = _context.Category.Find(id);
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
        public IActionResult EditCategoryPOST(Category obj)
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
        public IActionResult DeleteCategoryPOST(int? id)
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


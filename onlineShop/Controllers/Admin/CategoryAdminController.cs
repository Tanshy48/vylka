using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using onlineShop.Areas.Entity;
using onlineShop.Areas.Identity.Data;
using onlineShop.Models;

namespace onlineShop.Controllers.Admin
{
    [Authorize(Roles = "Адмін")]
    public class CategoryAdminController : Controller
    {
        private readonly OnlineShopContext _context;

        public CategoryAdminController(OnlineShopContext context)
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
        public IActionResult EditCategoryPost(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var p = new Category()
                {
                    Id = model.Id,
                    Name = model.Name,
                };
                _context.Category.Update(p);
                _context.SaveChanges();
            }

            return RedirectToAction("Categories");
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
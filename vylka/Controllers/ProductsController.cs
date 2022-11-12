using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Drawing;
using vylka.Areas.Entity;
using vylka.Data;
using vylka.Models;

namespace vylka.Controllers
{
    public class ProductsController : Controller
    {
        private readonly vylkaContext _context;
        public ProductsController(vylkaContext db)
        {
            _context = db;
        }
        public IActionResult Refrigerators()
        {
            return View(_context.Product.ToList());
        }
        public IActionResult TVs()
        {
            return View(_context.Product.ToList());
        }
        public IActionResult Vacuums()
        {
            return View(_context.Product.ToList());
        }
        public IActionResult Conditioners()
        {
            return View(_context.Product.ToList());
        }
        [HttpPost]
        public IActionResult AddProductToCart(int id)
        {

            var currentAccount = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

            if (currentAccount == null)
            {
                return RedirectToAction("/Identity/Account/Register");
            }

            var delivery = _context.Cart.OrderBy(o => o.Id).LastOrDefault(u => u.CartUserId == currentAccount);

            if (delivery == null || delivery.IsActive == false)
            {
                var userOder = new Cart()
                {
                    CreateCart = DateAndTime.Now,
                    IsActive = true,
                    CartUserId = currentAccount,
                };

                _context.Cart.Add(userOder);
                _context.SaveChanges();
                return View();
            }

            return View();
        }


    }


    
}
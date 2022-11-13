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
        [HttpGet]
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
        public IActionResult Refrigerators(int? id)
        {

            var currentAccount = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

            if (currentAccount == null)
            {
                return Redirect("/Identity/Account/Register");
            }

            var currentUserCart = _context.Cart.OrderBy(o => o.Id).LastOrDefault(u => u.CartUserId == currentAccount);

            if (currentUserCart == null || currentUserCart.IsActive == false)
            {
                var userOder = new Cart()
                {
                    CreateCart = DateAndTime.Now,
                    IsActive = true,
                    CartUserId = currentAccount,
                };

                _context.Cart.Add(userOder);
                _context.SaveChanges();
                return View("Refrigerators");
            }

            var selectedProduct = _context.Product.FirstOrDefault(p => p.Id == id);

            var item = _context.CartItem.FirstOrDefault(i =>
                i.ProductId == id && i.CartId == currentUserCart.Id);

            if (item == null)
            {
                var order = new CartItem()
                {
                    ProductId = selectedProduct.Id,
                    Quantity = 1,
                    Price = selectedProduct.Price,
                    CartId = currentUserCart.Id,
                    Product = selectedProduct,
                    ProductName = selectedProduct.ProductName,
                };
                _context.CartItem.Add(order);
                _context.SaveChanges();
            }
            else
            {
                item.Quantity++;
                /*
                _context.CartItem
                    .FirstOrDefault(i => i.ProductId == id && i.CartId == currentUserCart.Id)
                    .Quantity++;*/
                _context.SaveChanges();
            }
            return RedirectToAction("Refrigerators");

        }


    }


    
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vylka.Areas.Entity;
using vylka.Data;
using vylka.Models;

namespace vylka.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly vylkaContext _context;

        public ShoppingCartController(vylkaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var currentAccount = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (currentAccount == null)
            {
                return Redirect("/Identity/Account/Register");
            }
            var delivery = GetDelivery();
            if (delivery.IsActive == false)
            {
                return RedirectToAction("Index", "Home");
            }
            var items = _context.CartItem.Select(s => s).Where(w => w.CartId == delivery.Id);
            return View(items);
        }
        
        [HttpGet]
        public IActionResult NewOrder()
        {
            return View();
        }
    
        [HttpPost]
        public IActionResult NewOrder(ShippingDetail shippingDetail)
        {
            var currentAccount = _context.Users.FirstOrDefault(u => u.UserName == User.Identity!.Name);
            if (currentAccount != null) shippingDetail.UserId = currentAccount;
            
            shippingDetail.CreateDelivery = DateTime.Now;
            
            shippingDetail.TotalPrice = calculate(); 
            
            _context.ShippingDetail.Add(shippingDetail);
            _context.SaveChanges();
            return RedirectToAction("NewOrder");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeQuantity(int id, string operation)
        {
            var item = await _context.CartItem.FirstOrDefaultAsync(i => i.Id == id);
            if (operation == "+")
                ++item.Quantity;
            else if (operation == "-")
                --item.Quantity;
            else
                return BadRequest("Not valid");

            _context.CartItem.Update(item);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.CartItem.FirstOrDefaultAsync(i => i.Id == id);
            _context.CartItem.Remove(item);
            _context.SaveChanges();
            return Ok();
        }

        private Cart GetDelivery()
        {
            var currentUser = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

            if (currentUser == null)
            {
                currentUser = _context.Users.FirstOrDefault(u => u.Id == currentUser.Id);
            }

            return _context.Cart.OrderBy(o => o.Id).LastOrDefault(u => u.CartUserId == currentUser);
        }

        private double calculate()
        {
            var currentAccount = _context.Users.FirstOrDefault(u => u.UserName == User.Identity!.Name);
            var currentCart = _context.Cart.FirstOrDefault(u => u.CartUserId == currentAccount);
            var TotalPrice = 0.0;
            foreach (var item in _context.CartItem.Where(u => u.CartId == currentCart.Id))
            {
                var sum = item.Price * item.Quantity;
                TotalPrice += sum;
            }
            return TotalPrice;
        }
        
    }
}
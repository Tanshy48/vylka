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
            if (delivery == null || delivery.IsActive == false)
            {
                return RedirectToAction("Index", "Home");
            }
            var items = _context.CartItem.Select(s => s).Where(w => w.CartId == delivery.Id);
            return View(items);
        }

        public IActionResult NewOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewOrder(ShippingDetail shippingDetail)
        {
            var currentAccount = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            shippingDetail.CreateDelivery = DateTime.Now;
            shippingDetail.UserId = currentAccount;
            
            if (ModelState.IsValid)
            {
                _context.ShippingDetail.Update(shippingDetail);
                _context.SaveChanges();
                return Redirect("/Home");

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeQuantity(int id, string operation)
        {
            var item = await _context.CartItem.FirstOrDefaultAsync(i => i.Id == id);
            switch (operation) 
            {
                case "+":
                    ++item.Quantity;
                    break;
                case "-":
                    --item.Quantity;
                    break;
                default:
                    return BadRequest("Not valid");
            }
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
        
    }
}
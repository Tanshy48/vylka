using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vylka.Areas.Entity;
using vylka.Areas.Identity.Data;
using vylka.Models;

namespace vylka.Controllers
{
    [Authorize]
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
        
        [HttpGet]
        public IActionResult OrderCompleted()
        {
            int lastId = _context.ShippingDetail.Max(v => v.Id);
            var lastOrder = _context.ShippingDetail.Find(lastId);
            return View(lastOrder);
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewOrder(ShippingDetailModel model)
        {
            var currentAccount = _context.Users.FirstOrDefault(u => u.UserName == User.Identity!.Name);
            if (currentAccount != null)
            {
                
                    ShippingDetail sd = new ShippingDetail()
                    {
                        Id = model.Id,
                        CreateDelivery = DateTime.Now,
                        TotalPrice = Calculate(),
                        District = model.District,
                        City = model.City,
                        Address = model.Address,
                        DeliveryType = model.DeliveryType,
                        User = currentAccount,
                        UserId = currentAccount.Id,
                    };
                    _context.ShippingDetail.Add(sd);
                
            }

            var items = _context.CartItem.Where(u => u.Cart.CartUserId == currentAccount);
            
                foreach (var item in _context.CartItem.Where(u => u.Cart.CartUserId == currentAccount))
                {
                    _context.CartItem.Remove(item);
                }

                var delivery = GetDelivery();
            delivery.IsActive = false;
            
            _context.SaveChanges();
            return RedirectToAction("OrderCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeQuantity(int id, string operation)
        {
            var item = await _context.CartItem.FirstOrDefaultAsync(i => i.Id == id);
            if (item != null)
            {
                if (operation == "+" ) ++item.Quantity;
                else if (operation == "-") --item.Quantity;
                else return BadRequest("Not valid");
                
                _context.CartItem.Update(item);
            }
            
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.CartItem.FirstOrDefaultAsync(i => i.Id == id);
            if (item != null) _context.CartItem.Remove(item);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private Cart GetDelivery()
        {
            var currentUser = _context.Users.FirstOrDefault(u => u.UserName == User.Identity!.Name);

            return _context.Cart.OrderBy(o => o.Id).LastOrDefault(u => u.CartUserId == currentUser) ?? throw new InvalidOperationException();
        }

        private double Calculate()
        {
            var currentAccount = _context.Users.FirstOrDefault(u => u.UserName == User.Identity!.Name);
            var currentCart = _context.Cart.FirstOrDefault(u => u.CartUserId == currentAccount);
            var totalPrice = 0.0;
            foreach (var item in _context.CartItem.Where(u => currentCart != null && u.CartId == currentCart.Id))
            {
                var sum = item.Price * item.Quantity;
                totalPrice += sum;
            }
            return totalPrice;
        }
        
    }
}
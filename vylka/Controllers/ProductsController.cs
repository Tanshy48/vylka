using Microsoft.AspNetCore.Mvc;
using vylka.Areas.Entity;
using vylka.Areas.Identity.Data;

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
        public IActionResult Index(int id)
        {
            return View(_context.Product.Where(p => p.CategoryId == id));
        }
        
        [HttpPost]
        public IActionResult AddToCart(int id)
        {

            var currentAccount = _context.Users.FirstOrDefault(u => u.UserName == User.Identity!.Name);

            var currentUserCart = _context.Cart.OrderBy(o => o.Id).LastOrDefault(u => u.CartUserId == currentAccount);

            if (currentUserCart is { IsActive: false })
            {
                currentUserCart.IsActive = true;
                _context.SaveChanges();
                
            }

            var selectedProduct = _context.Product.FirstOrDefault(p => p.Id == id);

            var item = _context.CartItem.FirstOrDefault(i =>
                currentUserCart != null && i.ProductId == id && i.CartId == currentUserCart.Id);

            if (item == null && selectedProduct!=null && currentUserCart!=null)
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
                if (item != null) item.Quantity++;
                _context.SaveChanges();
            }
            return Ok();
        }
    }   
}
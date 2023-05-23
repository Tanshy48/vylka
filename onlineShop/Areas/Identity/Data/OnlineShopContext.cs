#nullable disable
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using onlineShop.Areas.Entity;

namespace onlineShop.Areas.Identity.Data;

public class OnlineShopContext : IdentityDbContext<IdentityUser>
{
    public DbSet<CartItem> CartItem { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Cart> Cart { get; set; }
    public DbSet<ShippingDetail> ShippingDetail { get; set; }

    public OnlineShopContext(DbContextOptions<OnlineShopContext> options)
        : base(options)
    {
    }
}

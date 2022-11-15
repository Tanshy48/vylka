#nullable disable
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using vylka.Areas.Entity;

namespace vylka.Areas.Identity.Data;

public class vylkaContext : IdentityDbContext<IdentityUser>
{
    public DbSet<CartItem> CartItem { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Cart> Cart { get; set; }
    public DbSet<ShippingDetail> ShippingDetail { get; set; }

    public vylkaContext(DbContextOptions<vylkaContext> options)
        : base(options)
    {
    }
}

#nullable disable
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using vylka.Areas.Entity;
using vylka.Models;

namespace vylka.Data;

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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

    }

}

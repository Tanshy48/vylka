#nullable disable
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using vylka.Areas.Entity;
using vylka.Models;

namespace vylka.Data;

public class vylkaContext : IdentityDbContext<User>
{
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

    public DbSet<User> User { get; set; }
    public DbSet<ShippingDetail> ShippingDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Cart> Carts { get; set; }




}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using vylka.Models;
using vylka.Areas.DB;

namespace vylka.Data;

public class vylkaContext : IdentityDbContext<IdentityUser>
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

    public DbSet<vylka.Models.UserModel> UserModel { get; set; }
    public DbSet<ShippingDetail> ShippingDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Cart> Carts { get; set; }




}

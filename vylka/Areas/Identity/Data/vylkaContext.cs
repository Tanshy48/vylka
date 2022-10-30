using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using vylka.Models;

namespace vylka.Data;

public class vylkaContext : IdentityDbContext<UserModel>
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

    public DbSet<UserModel> UserModel { get; set; }
    public DbSet<ShippingDetailModel> ShippingDetails { get; set; }
    public DbSet<ProductModel> Products { get; set; }
    public DbSet<CategoryModel> Categories { get; set; }
    public DbSet<CartModel> Carts { get; set; }




}

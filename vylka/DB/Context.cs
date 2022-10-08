using Microsoft.EntityFrameworkCore;
using vylka.DB.Entities;

namespace vylka.DB
{
    public class Context : DbContext
    {
        protected readonly IConfiguration Configuration;
        public Context(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if(!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ShippingDetail> ShippingDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasOne(u => u.Cart)
                .WithOne(p => p.User)
                .HasForeignKey<Cart>(p => p.UserId);
        }

    }
}

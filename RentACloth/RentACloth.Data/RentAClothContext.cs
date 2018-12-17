using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentACloth.Data.Models;
using RentACloth.Data.Models.Entities;

namespace RentACloth.Data
{
    public class RentAClothContext : IdentityDbContext<RentAClothUser>
    {
        public RentAClothContext(DbContextOptions<RentAClothContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<Cloth> Cloths { get; set; }
        public DbSet<Watch> Watches { get; set; }
        public DbSet<Accessories> Accessories{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cloth>();
            builder.Entity<Shoe>();
            builder.Entity<Watch>();
            builder.Entity<Accessories>();

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}

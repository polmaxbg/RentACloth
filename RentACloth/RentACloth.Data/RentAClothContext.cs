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
        public DbSet<OrderProduct> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<Cloth> Cloths { get; set; }
        public DbSet<Watch> Watches { get; set; }
        public DbSet<Accessories> Accessories{ get; set; }

        public DbSet<ShoppingBag> ShoppingBags { get; set; }

        public DbSet<ShoppingBagProduct> ShoppingBagProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cloth>();
            builder.Entity<Shoe>();
            builder.Entity<Watch>();
            builder.Entity<Accessories>();

            builder.Entity<Product>()
                .HasDiscriminator<string>("ProductType")
                .HasValue<Cloth>("Cloth")
                .HasValue<Shoe>("Shoe")
                .HasValue<Accessories>("Accessories")
                .HasValue<Watch>("Watch");

            builder.Entity<ShoppingBagProduct>().HasKey(x => new { x.ProductId, x.ShoppingBagId });

            builder.Entity<ShoppingBag>()
                .HasOne(x => x.RentAClothUser)
                .WithOne(x => x.ShoppingBag)
                .HasForeignKey<RentAClothUser>(x => x.ShoppingBagId)
                .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}

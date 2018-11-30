using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentACloth.Data.Models;

namespace RentACloth.Data
{
    public class ApplicationDbContext: IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Accessories> Accessories{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Shoes> Shoes { get; set; }
        public DbSet<Watch> Watches { get; set; }
        public DbSet<Clothes> Clothes{ get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}

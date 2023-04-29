using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TakeawayAPI.Data.Models;

namespace TakeawayAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base() { }
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Category { get; set; }
        public DbSet<Dish> Dish { get; set; }

        // we can add data by this way
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole { Name = "Customer", NormalizedName = "CUSTOMER" },
                    new IdentityRole { Name = "Manager", NormalizedName = "MANAGER" }
                );
        }

    }
}

using Microsoft.AspNetCore.Identity;
using TakeawayAPI.Data.DTOs;
using TakeawayAPI.Data.Models;

namespace TakeawayAPI.Data
{
    public static class DbInitializer
    {
        public async static void Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            if (context.Category.Any()) return;

            // add roles
            var user = new ApplicationUser()
            {
                Email = "likunhui@hotmail.com",
                UserName = "Admin",
                Address = "3 Russel Street"                
            };
            await userManager.CreateAsync(user, "P@ssw0rd");

            await userManager.AddToRoleAsync(user, "Manager");

            // add categories
            var categories = new List<Category>()
            {
                new Category
                {
                    Description = "Fish & Chips"
                },
                new Category
                {
                    Description = "Burgers"
                },
                new Category
                {
                    Description = "Chinese"
                },
                new Category
                {
                    Description = "Meal Deals"
                }
            };

            foreach(var category in categories)
            {
                context.Category.Add(category);                
            }

            context.SaveChanges();
            

        }
    }
}

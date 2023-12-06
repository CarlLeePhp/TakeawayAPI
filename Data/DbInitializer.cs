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

            // add dishes
            var dishes = new List<Dish>()
            {
                // 1 Fish & Chips
                new Dish
                {
                    Name = "Potato Slice",
                    Price = 1f,
                    CategoryId = 1
                },
                new Dish
                {
                    Name = "Ham & Cheese Battered",
                    Price = 2.5f,
                    CategoryId = 1
                },
                new Dish
                {
                    Name = "Fish",
                    Price = 3.8f,
                    CategoryId = 1
                },
                // 2 Burgers
                new Dish
                {
                    Name = "Plain - Small",
                    Price = 4f,
                    CategoryId = 2
                },
                new Dish
                {
                    Name = "Plain - Large",
                    Price = 6.8f,
                    CategoryId = 2
                },
                new Dish
                {
                    Name = "Cheese - Small",
                    Price = 5.2f,
                    CategoryId = 2
                },
                new Dish
                {
                    Name = "Cheese - Large",
                    Price = 6.8f,
                    CategoryId = 3
                },
                // 3 Chinese
                new Dish
                {
                    Name = "Chicken Chow Mein - Small",
                    Price = 10.5f,
                    CategoryId = 3
                },
                new Dish
                {
                    Name = "Chicken Chow Mein - Large",
                    Price = 12.5f,
                    CategoryId = 3
                },
                new Dish
                {
                    Name = "Beef Fried Rice - Small",
                    Price = 10f,
                    CategoryId = 3
                },
                new Dish
                {
                    Name = "Beef Fried Rice - Large",
                    Price = 12f,
                    CategoryId = 3
                },
                // 4 Meal Deals
                new Dish
                {
                    Name = "Meal Deal A",
                    Price = 30f,
                    CategoryId = 4
                },
                new Dish
                {
                    Name = "Meal Deal B",
                    Price = 42f,
                    CategoryId = 4
                },
                new Dish
                {
                    Name = "Meal Deal C",
                    Price = 55f,
                    CategoryId = 4
                }
            };

            foreach (var dish in dishes)
            {
                context.Dish.Add(dish);
            }

            context.SaveChanges();
            

        }
    }
}

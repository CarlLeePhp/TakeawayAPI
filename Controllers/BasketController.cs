using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TakeawayAPI.Data;
using TakeawayAPI.Data.Models;
using TakeawayAPI.Data.DTOs;

namespace TakeawayAPI.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly ApplicationDbContext _context;
        public BasketController(ApplicationDbContext context) {
            _context = context;
        }

        [HttpGet(Name = "GetBasket")]
        public async Task<ActionResult<BasketDto>> GetBasket()
        {
            // Get BuyerId from cookies
            var basket = await RetrievBasket();

            if (basket == null) return NotFound();

            return MapBasketToDto(basket);
        }

        [HttpPost] // api/basket?productId=1?quantity=3
        public async Task<ActionResult<BasketDto>> AddItemToBasket(int dishId, int quantity)
        {
            // get basket
            var basket = await RetrievBasket();
            // create basket
            if(basket == null)
            {
                basket = CreateBasket();
            }
            //get dish
            var dish = await _context.Dish.FindAsync(dishId);
            if (dish == null) return NotFound();
            //add item
            basket.AddItem(dish, quantity);
            // save changes
            var result = await _context.SaveChangesAsync() > 0;
            if (result) return CreatedAtRoute("GetBasket", MapBasketToDto(basket));
            return BadRequest(new ProblemDetails { Title = "Problem saving item to basket"});
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveBasketItem(int dishId, int quantity)
        {
            // get basket
            var basket = await RetrievBasket();
            if(basket == null) return NotFound();
            
            basket.RemoveItem(dishId, quantity);
            var result = await _context.SaveChangesAsync() > 0;
            if (result) return Ok();
            return BadRequest(new ProblemDetails { Title = "Problem removing item from basket" });
        }

        private async Task<Basket> RetrievBasket()
        {
            return await _context.Basket
                .Include(b => b.Items)
                .ThenInclude(i => i.Dish)
                .FirstOrDefaultAsync(b => b.BuyerId == Request.Cookies["buyerId"]);
        }

        private Basket CreateBasket()
        {
            var buyerId = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions { IsEssential = true, Expires = DateTime.Now.AddDays(10), SameSite=SameSiteMode.None, Secure=true };
            Response.Cookies.Append("buyerId", buyerId, cookieOptions);
            var basket = new Basket { BuyerId = buyerId };

            _context.Basket.Add(basket);
            return basket;
        }

        private BasketDto MapBasketToDto(Basket basket)
        {
            return new BasketDto
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                Items = basket.Items.Select(item => new BasketItemDto
                {
                    DishId = item.DishId,
                    Name = item.Dish.Name,
                    Price = item.Dish.Price,
                    Description = item.Dish.Description,
                    Quantity = item.Quantity
                }).ToList()
            };
        }
    }
}

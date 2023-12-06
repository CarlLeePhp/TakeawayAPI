using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TakeawayAPI.Data;
using TakeawayAPI.Data.DTOs;
using TakeawayAPI.Data.Models;

namespace TakeawayAPI.Controllers
{
    public class DishesController : BaseApiController
    {
        private readonly ApplicationDbContext _context;
        public DishesController(ApplicationDbContext context) {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<DishDto>> GetDishes()
        {
            var dishes = _context.Dish.Include(d => d.Category).ToList();
            List<DishDto> dishDtos = new List<DishDto>();
            foreach (var dish in dishes)
            {
                dishDtos.Add(new DishDto
                {
                    Id = dish.Id,
                    Name = dish.Name,
                    Description = dish.Description,
                    Price = dish.Price,
                    CategoryId = dish.CategoryId,
                    CategoryName = dish.Category.Description
                });
            }

            return Ok(dishDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<DishDto> GetDish(int id)
        {
            var dish = _context.Dish.Include(d => d.Category).FirstOrDefault(d => d.Id == id);
            if (dish == null) { return NotFound(); }
            DishDto dishDto = new DishDto
            {
                Id = dish.Id,
                Name = dish.Name,
                Description = dish.Description,
                Price = dish.Price,
                CategoryId = dish.CategoryId,
                CategoryName = dish.Category.Description
            };

            return Ok(dishDto);
        }

        [HttpPost]
        public async Task<ActionResult> AddCategory(Dish dish)
        {
            _context.Dish.Add(dish);

            var result = await _context.SaveChangesAsync() > 0;
            if (result) return StatusCode(201);

            return BadRequest("Saving Error");
        }

    }
}

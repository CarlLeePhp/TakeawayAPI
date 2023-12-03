using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TakeawayAPI.Data;
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
        public ActionResult<List<Dish>> GetDishes()
        {
            var dishes = _context.Dish.Include(d => d.Category).ToList();

            return Ok(dishes);
        }

        [HttpGet("{id}")]
        public ActionResult<Dish> GetDish(int id)
        {
            var dish = _context.Dish.Include(d => d.Category).FirstOrDefault(d => d.Id == id);
            if (dish == null) { return NotFound(); }

            return Ok(dish);
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

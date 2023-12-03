using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TakeawayAPI.Data;
using TakeawayAPI.Data.Models;

namespace TakeawayAPI.Controllers
{
    public class CategoriesController : BaseApiController
    {
        private readonly ApplicationDbContext _context;
        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async  Task<ActionResult<List<Category>>> GetCategories()
        {
            var categories = await _context.Category.ToListAsync();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _context.Category.FirstOrDefaultAsync(c => c.Id == id);
            if(category == null) { return NotFound(); }

            return category;
        }

        [HttpPost]
        public async Task<ActionResult> AddCategory(Category category)
        {
            _context.Category.Add(category);

            var result = await _context.SaveChangesAsync() > 0;
            if (result) return StatusCode(201);

            return BadRequest("Saving Error");
        }
    }
}

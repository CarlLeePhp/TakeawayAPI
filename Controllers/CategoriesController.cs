using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TakeawayAPI.Data;
using TakeawayAPI.Data.DTOs;
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
        public async  Task<ActionResult<List<CategoryDto>>> GetCategories()
        {
            var categories = await _context.Category.Include(c => c.Dishes).ToListAsync();
            List<CategoryDto> categoryDtos = new List<CategoryDto>();
            foreach (var category in categories)
            {
                categoryDtos.Add(new CategoryDto
                {
                    Id = category.Id,
                    Description = category.Description,
                    DishDtos = category.Dishes.Select(d => new DishDto
                    {
                        Id = d.Id,
                        Name = d.Name,
                        Description = d.Description,
                        Price = d.Price,
                        CategoryId = d.CategoryId,
                        CategoryName = category.Description
                    }).ToList()
                });
            }

            return Ok(categoryDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var category = await _context.Category.Include(c => c.Dishes).FirstOrDefaultAsync(c => c.Id == id);
            if(category == null) { return NotFound(); }
            CategoryDto categoryDto = new CategoryDto
            {
                Id = category.Id,
                Description = category.Description,
                DishDtos = category.Dishes.Select(d => new DishDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description,
                    Price = d.Price,
                    CategoryId = d.CategoryId,
                    CategoryName = category.Description
                }).ToList()
            };
            return categoryDto;
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

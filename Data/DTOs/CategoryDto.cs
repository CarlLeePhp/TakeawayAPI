namespace TakeawayAPI.Data.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;

        public List<DishDto> DishDtos { get; set; }
    }
}

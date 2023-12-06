namespace TakeawayAPI.Data.DTOs
{
    public class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }

        public int CategoryId { get; set; }
        public string  CategoryName { get; set; }
    }
}

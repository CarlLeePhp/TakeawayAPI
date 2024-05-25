namespace TakeawayAPI.Data.DTOs
{
    public class BasketItemDto
    {
        public int Quantity { get; set; }
        public int DishId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
    }
}

namespace TakeawayAPI.Data.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Price { get; set; }
        public string MyProperty { get; set; } = string.Empty;
        public float Discount { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}

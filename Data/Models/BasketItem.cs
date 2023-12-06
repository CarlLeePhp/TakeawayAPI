namespace TakeawayAPI.Data.Models
{
    public class BasketItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        // navigation properties
        public int DishId { get; set; }
        public Dish Dish { get; set; }

        public int BasketId { get; set; }
        public Basket Basket { get; set; }

    }
}
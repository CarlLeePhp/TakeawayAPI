namespace TakeawayAPI.Data.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasketItem> Items { get; set; } = new();


        public void AddItem(Dish dish, int quantity)
        {
            if (Items.All(item => item.DishId != dish.Id))
            {
                Items.Add(new BasketItem() { Dish =  dish, Quantity = quantity });
            }

            var existingItem = Items.FirstOrDefault(item => item.DishId == dish.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
        }

        public void RemoveItem(int dishId, int quantity)
        {
            var item = Items.FirstOrDefault(item => item.DishId == dishId);
            if(item == null)
            {
                return;
            }

            item.Quantity -= quantity;
            if(item.Quantity <= 0) Items.Remove(item);
        }
    }
}

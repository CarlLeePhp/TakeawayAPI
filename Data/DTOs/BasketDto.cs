using TakeawayAPI.Data.Models;

namespace TakeawayAPI.Data.DTOs
{
    public class BasketDto
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasketItemDto> Items { get; set; } = new();
    }
}

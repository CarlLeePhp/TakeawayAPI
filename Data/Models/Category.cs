﻿namespace TakeawayAPI.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;

        // navigation properties
        public List<Dish> Dishes { get; set; }
    }
}

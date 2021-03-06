using System;

namespace NotShopee.Api.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; }
        public DateTime BoughtAt { get; set; }
    }
}
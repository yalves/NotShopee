using System;

namespace NotShopee.Client.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; }
        public DateTime BoughtAt { get; set; }
    }
}
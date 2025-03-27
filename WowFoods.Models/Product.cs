using System;
using System.Collections.Generic;
using System.Text;

namespace WowFoods.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int AddedBy { get; set; }
        public User User { get; set; }
    }
}

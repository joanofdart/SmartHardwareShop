using System;
using System.Collections.Generic;

namespace SmartHardwareShop.Models
{
    public class Cart
    {
        public Guid CartId { get; set; }
        public Dictionary<string, Product> Products { get; set; }
        public bool CartClosed { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

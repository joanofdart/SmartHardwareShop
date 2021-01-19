using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHardwareShop.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImage { get; set; }
    }
}

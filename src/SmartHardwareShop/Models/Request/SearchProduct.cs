using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHardwareShop.Models
{
    public class SearchProduct
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductSeller { get; set; }
        public string ProductDescription { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
    }
}

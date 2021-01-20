using System;

namespace SmartHardwareShop.Models
{
    public class AddToCartModel
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
    }
}

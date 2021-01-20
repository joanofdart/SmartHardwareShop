using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHardwareShop.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid CartId { get; set; }
        public Guid UserId { get; set; }
    }
}

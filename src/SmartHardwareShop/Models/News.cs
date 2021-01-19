using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHardwareShop.Models
{
    public class News
    {
        public Guid NewsId { get; set; }
        public string NewsName { get; set; }
        public string NewsContent { get; set; }
        public string NewsBanner { get; set; }
    }
}

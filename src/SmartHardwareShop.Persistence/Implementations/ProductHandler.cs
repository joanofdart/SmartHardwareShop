using Microsoft.Extensions.Caching.Memory;
using SmartHardwareShop.Models;
using SmartHardwareShop.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHardwareShop.Persistence.Implementations
{
    public class ProductHandler : IMemoryDatabase<Product>
    {
        private readonly IMemoryCache _memoryCache;

        public ProductHandler(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Product AddItem(Product key)
        {
            throw new NotImplementedException();
        }

        public Product GetItem(Guid key)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(Product key)
        {
            throw new NotImplementedException();
        }
    }
}

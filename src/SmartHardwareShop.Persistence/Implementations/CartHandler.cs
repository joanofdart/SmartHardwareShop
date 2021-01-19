using Microsoft.Extensions.Caching.Memory;
using SmartHardwareShop.Models;
using SmartHardwareShop.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHardwareShop.Persistence.Implementations
{
    class CartHandler : IMemoryDatabase<Cart>
    {
        private readonly IMemoryCache _memoryCache;

        public CartHandler(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Cart AddItem(Cart cart)
        {
            cart.CartId = Guid.NewGuid();
            return _memoryCache.Set($"{nameof(Cart)}_{cart.CartId}", cart);
        }

        public Cart GetItem(Guid key)
        {
            if (!_memoryCache.TryGetValue($"{nameof(Cart)}_{key}", out Cart cart)) {
                return null;
            }

            return cart;
        }

        public void RemoveItem(Cart cart)
        {
            _memoryCache.Remove($"{nameof(Cart)}_{cart.CartId}");
        }
    }
}

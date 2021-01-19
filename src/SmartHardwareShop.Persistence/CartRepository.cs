using SmartHardwareShop.Interfaces.Repositories;
using SmartHardwareShop.Models;
using SmartHardwareShop.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHardwareShop.Persistence
{
    public class CartRepository : ICartRepository
    {
        private readonly IMemoryDatabase<Cart> _memoryDatabase;

        public CartRepository(IMemoryDatabase<Cart> memoryDatabase)
        {
            _memoryDatabase = memoryDatabase;
        }

        public async Task<Cart> CreateCart()
        {
            return await Task.Run(() => {
                return _memoryDatabase.AddItem(new Cart());
            });
        }

        public async Task<Cart> GetCart(Guid cartId)
        {
            var _cartFromDB = await Task.Run(() => {
                return _memoryDatabase.GetItem(cartId);

                //return new Cart
                //{
                //    CartId = Guid.NewGuid(),
                //    Products = new List<Product>(),
                //    TotalPrice = 398938.39m,
                //};
            });

            return _cartFromDB;
        }



    }
}

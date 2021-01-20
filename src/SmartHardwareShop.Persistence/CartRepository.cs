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
        private readonly ICartHandler _cartHandler;

        public CartRepository(ICartHandler cartHandler)
        {
            _cartHandler = cartHandler;
        }

        public async Task<Cart> CreateCart()
        {
            return await Task.Run(() => {
                return _cartHandler.Create(new Cart());
            });
        }

        public async Task<Cart> GetCart(Guid cartId)
        {
            var _cartFromDB = await Task.Run(() => {
                return _cartHandler.ById(cartId);

                //return new Cart
                //{
                //    CartId = Guid.NewGuid(),
                //    Products = new List<Product>(),
                //    TotalPrice = 398938.39m,
                //};
            });

            return _cartFromDB;
        }

        public async Task CloseCart(Guid cartId)
        {
            await Task.Run(() => {
                _cartHandler.Close(cartId);
            });
        }
    }
}

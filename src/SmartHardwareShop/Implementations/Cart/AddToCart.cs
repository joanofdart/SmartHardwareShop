using SmartHardwareShop.Interfaces.Repositories;
using SmartHardwareShop.Interfaces.UseCases;
using SmartHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartHardwareShop.Implementations
{
    public class AddToCart : IAddToCart
    {
        private readonly ICartRepository _cartRepository;

        public AddToCart(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Cart> Execute(Guid productId, Guid cartId)
        {
            return await _cartRepository.Add(productId, cartId);
        }
    }
}

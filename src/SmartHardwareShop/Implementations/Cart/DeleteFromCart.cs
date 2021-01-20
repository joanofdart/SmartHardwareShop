using SmartHardwareShop.Interfaces.Repositories;
using SmartHardwareShop.Interfaces.UseCases;
using SmartHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartHardwareShop.Implementations
{
    public class DeleteFromCart : IDeleteFromCart
    {
        private readonly ICartRepository _cartRepository;

        public DeleteFromCart(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Cart> Execute(Guid productId, Guid cartId)
        {
            return await _cartRepository.Delete(productId, cartId);
        }
    }
}

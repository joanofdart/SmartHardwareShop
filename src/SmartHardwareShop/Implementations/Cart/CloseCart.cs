using SmartHardwareShop.Interfaces.Repositories;
using SmartHardwareShop.Interfaces.UseCases;
using SmartHardwareShop.Models;
using System;
using System.Threading.Tasks;

namespace SmartHardwareShop.Implementations
{
    public class CloseCart : ICloseCart
    {
        private readonly ICartRepository _cartRepository;

        public CloseCart(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Cart> ById(Guid cartId)
        {
            var _cartResponse = await _cartRepository.Clo(cartId);
            return _cartResponse;
        }
    }
}




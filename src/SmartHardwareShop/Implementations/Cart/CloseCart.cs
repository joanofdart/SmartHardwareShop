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

        public async Task Execute(Guid cartId)
        {
            await _cartRepository.Close(cartId);
        }
    }
}




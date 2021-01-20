using SmartHardwareShop.Interfaces.Repositories;
using SmartHardwareShop.Interfaces.UseCases;
using SmartHardwareShop.Models;
using System;
using System.Threading.Tasks;

namespace SmartHardwareShop.Implementations
{
    public class OpenCart : IOpenCart
    {
        private readonly ICartRepository _cartRepository;

        public OpenCart(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task Execute(Guid cartId)
        {
            await _cartRepository.Open(cartId);
        }
    }
}




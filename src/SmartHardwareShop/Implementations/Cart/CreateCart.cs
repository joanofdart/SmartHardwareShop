using SmartHardwareShop.Interfaces.Repositories;
using SmartHardwareShop.Interfaces.UseCases;
using SmartHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartHardwareShop.Implementations
{
    public class CreateCart : ICreateCart
    {
        private readonly ICartRepository _cartRepository;

        public CreateCart(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Cart> Execute()
        {
            return await _cartRepository.Create();
        }
    }
}

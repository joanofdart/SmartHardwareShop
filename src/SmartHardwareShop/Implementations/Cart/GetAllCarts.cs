using SmartHardwareShop.Interfaces.Repositories;
using SmartHardwareShop.Interfaces.UseCases;
using SmartHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHardwareShop.Implementations
{
    public class GetAllCarts : IGetAllCarts
    {
        private readonly ICartRepository _cartRepository;

        public GetAllCarts(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<List<Cart>> Execute()
        {
            var _cartResponse = await _cartRepository.GetAll();
            return _cartResponse;
        }
    }
}




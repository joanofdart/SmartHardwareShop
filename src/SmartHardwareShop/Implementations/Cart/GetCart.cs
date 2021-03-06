﻿using SmartHardwareShop.Interfaces.Repositories;
using SmartHardwareShop.Interfaces.UseCases;
using SmartHardwareShop.Models;
using System;
using System.Threading.Tasks;

namespace SmartHardwareShop.Implementations
{
    public class GetCart : IGetCart
    {
        private readonly ICartRepository _cartRepository;

        public GetCart(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Cart> Execute(Guid cartId)
        {
            var _cartResponse = await _cartRepository.Get(cartId);
            return _cartResponse;
        }
    }
}




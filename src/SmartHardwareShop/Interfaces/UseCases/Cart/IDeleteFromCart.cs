﻿using SmartHardwareShop.Models;
using System;
using System.Threading.Tasks;

namespace SmartHardwareShop.Interfaces.UseCases
{
    public interface IDeleteFromCart
    {
        Task<Cart> Execute(Guid productId, Guid cartId);
    }
}

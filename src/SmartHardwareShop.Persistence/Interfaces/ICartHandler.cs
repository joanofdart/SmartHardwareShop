using SmartHardwareShop.Models;
using System;
using System.Collections.Generic;

namespace SmartHardwareShop.Persistence.Interfaces
{
    public interface ICartHandler
    {
        Cart ById(Guid cardId);
        List<Cart> GetAll();
        Cart Create(Cart cart);
        void Close(Guid cartId);
        void Open(Guid cartId);
    }
}

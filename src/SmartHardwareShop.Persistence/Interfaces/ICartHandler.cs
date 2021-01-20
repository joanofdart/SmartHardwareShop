using SmartHardwareShop.Models;
using System;
using System.Collections.Generic;

namespace SmartHardwareShop.Persistence.Interfaces
{
    public interface ICartHandler
    {
        Cart Get(Guid cardId);
        List<Cart> GetAll();
        Cart Create(Cart cart);
        Cart AddProduct(Guid productId, Guid cartId);
        Cart DeleteProduct(Guid productId, Guid cartId);
        void Close(Guid cartId);
        void Open(Guid cartId);
    }
}

using SmartHardwareShop.Models;
using System;

namespace SmartHardwareShop.Persistence.Interfaces
{
    public interface ICartHandler
    {
        Cart ById(Guid cardId);
        Cart Create(Cart cart);
        void Close(Guid cartId);
    }
}

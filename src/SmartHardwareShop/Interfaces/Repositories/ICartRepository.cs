using SmartHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartHardwareShop.Interfaces.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> GetCart(Guid cartId);
        Task<Cart> CreateCart();
        Task CloseCart(Guid cartId);
    }
}

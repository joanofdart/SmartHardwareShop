using SmartHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartHardwareShop.Interfaces.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> Get(Guid cartId);
        Task<List<Cart>> GetAll();
        Task<Cart> Create();
        Task Close(Guid cartId);
        Task Open(Guid cartId);
    }
}

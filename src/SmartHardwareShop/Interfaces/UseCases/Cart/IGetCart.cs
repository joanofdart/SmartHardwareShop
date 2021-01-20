using SmartHardwareShop.Models;
using System;
using System.Threading.Tasks;

namespace SmartHardwareShop.Interfaces.UseCases
{
    public interface IGetCart
    {
        Task<Cart> Execute(Guid cartId);
    }
}

using SmartHardwareShop.Models;
using System;
using System.Threading.Tasks;

namespace SmartHardwareShop.Interfaces.UseCases
{
    public interface IOpenCart
    {
        Task Execute(Guid cartId);
    }
}

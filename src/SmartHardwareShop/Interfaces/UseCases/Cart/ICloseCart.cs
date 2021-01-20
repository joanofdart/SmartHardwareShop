using SmartHardwareShop.Models;
using System;
using System.Threading.Tasks;

namespace SmartHardwareShop.Interfaces.UseCases
{
    public interface ICloseCart
    {
        Task Execute(Guid cartId);
    }
}

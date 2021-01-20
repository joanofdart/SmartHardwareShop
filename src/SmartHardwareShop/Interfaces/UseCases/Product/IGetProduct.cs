using SmartHardwareShop.Models;
using System;
using System.Threading.Tasks;

namespace SmartHardwareShop.Interfaces.UseCases
{
    public interface IGetProduct
    {
        Task<Product> Execute(Guid productId);
    }
}

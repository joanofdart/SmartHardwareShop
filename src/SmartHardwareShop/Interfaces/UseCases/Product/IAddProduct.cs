using SmartHardwareShop.Models;
using System.Threading.Tasks;

namespace SmartHardwareShop.Interfaces.UseCases
{
    public interface IAddProduct
    {
        Task Execute(Product product);
    }
}

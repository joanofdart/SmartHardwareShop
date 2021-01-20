using SmartHardwareShop.Models;
using System.Threading.Tasks;

namespace SmartHardwareShop.Interfaces.UseCases
{
    public interface IAddProduct
    {
        Task Add(Product product);
    }
}

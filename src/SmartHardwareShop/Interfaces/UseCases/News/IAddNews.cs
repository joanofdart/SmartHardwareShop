using SmartHardwareShop.Models;
using System.Threading.Tasks;

namespace SmartHardwareShop.Interfaces.UseCases
{
    public interface IAddNews
    {
        Task Execute(News news);
    }
}

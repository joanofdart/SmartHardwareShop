using SmartHardwareShop.Models;
using System.Threading.Tasks;

namespace SmartHardwareShop.Interfaces.UseCases
{
    public interface IUpdateNews
    {
        Task Execute(News news);
    }
}

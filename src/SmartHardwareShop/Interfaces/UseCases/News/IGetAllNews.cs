using SmartHardwareShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHardwareShop.Interfaces.UseCases
{
    public interface IGetAllNews
    {
        Task<List<News>> Execute();
    }
}

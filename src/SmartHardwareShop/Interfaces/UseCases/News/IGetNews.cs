using SmartHardwareShop.Models;
using System;
using System.Threading.Tasks;

namespace SmartHardwareShop.Interfaces.UseCases
{
    public interface IGetNews
    {
        Task<News> Execute(Guid newsId);
    }
}

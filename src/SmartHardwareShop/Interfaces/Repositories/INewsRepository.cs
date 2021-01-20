using SmartHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHardwareShop.Interfaces.Repositories
{
    public interface INewsRepository
    {
        Task<List<News>> GetAll();
        Task<News> Get(Guid newsId);
        Task Add(News news);
        Task Delete(Guid newsId);
        Task DeleteAll();
        Task Update(News news);
    }
}

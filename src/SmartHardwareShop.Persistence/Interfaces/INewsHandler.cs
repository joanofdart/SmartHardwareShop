using SmartHardwareShop.Models;
using System;

namespace SmartHardwareShop.Persistence.Interfaces
{
    public interface INewsHandler
    {
        void Add(News news);
        void Remove(Guid newsId);
        void Update(News news);
    }
}

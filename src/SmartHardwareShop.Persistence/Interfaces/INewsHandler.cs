using SmartHardwareShop.Models;
using System;
using System.Collections.Generic;

namespace SmartHardwareShop.Persistence.Interfaces
{
    public interface INewsHandler
    {
        List<News> GetAll();
        News Get(Guid productId);
        void Add(News product);
        void Delete(Guid productId);
        void DeleteAll();
        void Update(News product);
    }
}

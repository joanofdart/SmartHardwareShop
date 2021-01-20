using SmartHardwareShop.Models;
using System;
using System.Collections.Generic;

namespace SmartHardwareShop.Persistence.Interfaces
{
    public interface IProductHandler
    {
        List<Product> GetAll();
        Product ById(Guid productId);
        void Add(Product product);
        void Remove(Guid productId);
        void Update(Product product);
    }
}

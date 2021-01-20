using SmartHardwareShop.Models;
using System;
using System.Collections.Generic;

namespace SmartHardwareShop.Persistence.Interfaces
{
    public interface IProductHandler
    {
        List<Product> GetAll();
        Product Get(Guid productId);
        List<Product> Search(Guid productId, string productName, string productSeller, string productDescription, decimal minPrice, decimal maxPrice);
        void Add(Product product);
        void Delete(Guid productId);
        void DeleteAll();
        void Update(Product product);
        void GenerateInitialProducts();
    }
}

using SmartHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHardwareShop.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product> Get(Guid productId);
        Task Add(Product product);
        Task Delete(Guid productId);
        Task DeleteAll();
        Task Update(Product product);
        Task Generate();
    }
}

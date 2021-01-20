using SmartHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartHardwareShop.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(Guid productId);
        Task AddProduct(Product product);
        Task DeleteProduct(Guid productId);
        Task UpdateProduct(Product product);
    }
}

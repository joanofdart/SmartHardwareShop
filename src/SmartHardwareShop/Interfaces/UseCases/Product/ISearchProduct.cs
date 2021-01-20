using SmartHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHardwareShop.Interfaces.UseCases
{
    public interface ISearchProduct
    {
        Task<List<Product>> Execute(Guid productId, string productName, string productSeller, string productDescription, decimal minPrice, decimal maxPrice);
    }
}

using SmartHardwareShop.Interfaces.Repositories;
using SmartHardwareShop.Interfaces.UseCases;
using SmartHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHardwareShop.Implementations
{
    public class SearchProduct : ISearchProduct
    {
        private readonly IProductRepository _productRepository;

        public SearchProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> Execute(Guid productId, string productName, string productSeller, string productDescription, decimal minPrice, decimal maxPrice)
        {
            var productFromDB = await _productRepository.Search(productId, productName, productSeller, productDescription, minPrice, maxPrice);
            return productFromDB;
        }
    }
}




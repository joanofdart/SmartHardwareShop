using SmartHardwareShop.Interfaces.Repositories;
using SmartHardwareShop.Interfaces.UseCases;
using SmartHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHardwareShop.Implementations
{
    public class GetProduct : IGetProduct
    {
        private readonly IProductRepository _productRepository;

        public GetProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> ById(Guid productId)
        {
            var productFromDB = await _productRepository.GetProductById(productId);
            return productFromDB;
        }
    }
}




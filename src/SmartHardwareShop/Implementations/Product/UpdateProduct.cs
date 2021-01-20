using SmartHardwareShop.Interfaces.Repositories;
using SmartHardwareShop.Interfaces.UseCases;
using SmartHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHardwareShop.Implementations
{
    public class UpdateProduct : IUpdateProduct
    {
        private readonly IProductRepository _productRepository;

        public UpdateProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Update(Product product)
        {
            await _productRepository.UpdateProduct(product);
        }
    }
}




using SmartHardwareShop.Interfaces.Repositories;
using SmartHardwareShop.Interfaces.UseCases;
using SmartHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHardwareShop.Implementations
{
    public class AddProduct : IAddProduct
    {
        private readonly IProductRepository _productRepository;

        public AddProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Add(Product product)
        {
            await _productRepository.AddProduct(product);
        }

    }
}




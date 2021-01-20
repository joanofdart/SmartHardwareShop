using SmartHardwareShop.Interfaces.Repositories;
using SmartHardwareShop.Interfaces.UseCases;
using SmartHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHardwareShop.Implementations
{
    public class GenerateInitialProducts : IGenerateInitialProducts
    {
        private readonly IProductRepository _productRepository;

        public GenerateInitialProducts(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Execute()
        {
            await _productRepository.Generate();
        }

    }
}




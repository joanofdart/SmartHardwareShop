using SmartHardwareShop.Interfaces.Repositories;
using SmartHardwareShop.Interfaces.UseCases;
using SmartHardwareShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHardwareShop.Implementations
{
    public class GetProducts : IGetProducts
    {
        private readonly IProductRepository _productRepository;

        public GetProducts(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> Execute()
        {
            var listOfProducts = await _productRepository.GetAll();
            return listOfProducts;
        }
    }
}




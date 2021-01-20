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

        public async Task<List<Product>> All()
        {
            var listOfProducts = await _productRepository.GetAllProducts();
            return listOfProducts;
        }
    }
}




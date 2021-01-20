using SmartHardwareShop.Interfaces.Repositories;
using SmartHardwareShop.Interfaces.UseCases;
using System;
using System.Threading.Tasks;

namespace SmartHardwareShop.Implementations
{
    public class DeleteAllProducts : IDeleteAllProducts
    {
        private readonly IProductRepository _productRepository;

        public DeleteAllProducts(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Execute()
        {
            await _productRepository.DeleteAll();
        }
    }
}




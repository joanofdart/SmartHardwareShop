using SmartHardwareShop.Interfaces.Repositories;
using SmartHardwareShop.Interfaces.UseCases;
using System;
using System.Threading.Tasks;

namespace SmartHardwareShop.Implementations
{
    public class RemoveProduct : IRemoveProduct
    {
        private readonly IProductRepository _productRepository;

        public RemoveProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Remove(Guid productId)
        {
            await _productRepository.DeleteProduct(productId);
        }
    }
}




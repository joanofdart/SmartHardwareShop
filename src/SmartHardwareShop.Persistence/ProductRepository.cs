using SmartHardwareShop.Interfaces.Repositories;
using SmartHardwareShop.Models;
using SmartHardwareShop.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHardwareShop.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductHandler _productHandler;

        public ProductRepository(IProductHandler productHandler)
        {
            _productHandler = productHandler;
        }

        public async Task<List<Product>> GetAll()
        {
            var listOfProducts = await Task.Run(() => {
                return _productHandler.GetAll();
            });

            return listOfProducts;
        }

        public async Task<Product> Get(Guid productId)
        {
            var productFromDb = await Task.Run(() => {
                return _productHandler.Get(productId);
            });

            return productFromDb;
        }

        public async Task Add(Product product)
        {
            await Task.Run(() => {
                _productHandler.Add(product);
            });
        }
        public async Task Generate()
        {
            await Task.Run(() => {
                _productHandler.GenerateInitialProducts();
            });
        }

        public async Task Delete(Guid productId)
        {
            await Task.Run(() => {
                _productHandler.Delete(productId);
            });
        }

        public async Task DeleteAll()
        {
            await Task.Run(() => {
                _productHandler.DeleteAll();
            });
        }

        public async Task Update(Product product)
        {
            await Task.Run(() => {
                _productHandler.Update(product);
            });
        }

        public async Task<List<Product>> Search(Guid productId, string productName, string productSeller, string productDescription, decimal minPrice, decimal maxPrice)
        {
            var listOfProducts = await Task.Run(() => {
                return _productHandler.Search(productId, productName, productSeller, productDescription, minPrice, maxPrice);
            });

            return listOfProducts;
        }
    }
}

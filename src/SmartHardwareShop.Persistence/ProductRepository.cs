﻿using SmartHardwareShop.Interfaces.Repositories;
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
                return _productHandler.ById(productId);
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
                _productHandler.Remove(productId);
            });
        }

        public async Task DeleteAll()
        {
            await Task.Run(() => {
                _productHandler.RemoveAll();
            });
        }

        public async Task Update(Product product)
        {
            await Task.Run(() => {
                _productHandler.Update(product);
            });
        }
    }
}

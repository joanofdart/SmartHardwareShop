using LiteDB;
using SmartHardwareShop.Models;
using SmartHardwareShop.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHardwareShop.Persistence.Implementations
{
    class ProductHandler : IProductHandler
    {
        private readonly LiteDatabase _liteDatabase;
        private readonly ILiteCollection<Product> _productsCollection;

        public ProductHandler(ILiteDbContext liteDbContext)
        {
            _liteDatabase = liteDbContext.Database;
            _productsCollection = _liteDatabase.GetCollection<Product>("products");
            _productsCollection.EnsureIndex(x => x.ProductId);
        }

        public List<Product> GetAll()
        {
            var list = _productsCollection.FindAll().ToList();
            return list;
        }

        public Product ById(Guid productId)
        {
            var product = _productsCollection.FindById(productId);
            return product;
        }
        public void Add(Product product)
        {
            product.ProductId = Guid.NewGuid();
            product.ProductImage = product.ProductImage ?? "https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png";
            _productsCollection.Insert(product);
        }

        public void Remove(Guid productId)
        {
            _productsCollection.Delete(productId);
        }

        public void Update(Product product)
        {
            _productsCollection.Update(product);
        }
    }
}

using LiteDB;
using SmartHardwareShop.Models;
using SmartHardwareShop.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SmartHardwareShop.Persistence.Implementations
{
    class ProductHandler : IProductHandler
    {
        private readonly LiteDatabase _liteDatabase;
        private readonly ILiteCollection<Product> _productsCollection;
        private readonly Random _random = new Random();
        private readonly string[] _defaultShops = {
            "Amazon",
            "MarktMedia",
            "Corsair",
            "CoolBlue",
            "Heureka",
            "Alza",
            "Facebook Marketplace",
            "ScanUK",
            "Ebay",
        };
        private readonly string[] _defaultProductNames = { 
            "RTX Nvidia 3090",
            "RTX Nvidia 3090 Founders Edition",
            "RTX Nvidia 3080",
            "RTX Nvidia 3080 Founders Edition",
            "RTX Nvidia 3070",
            "RTX Nvidia 3070 Founders Edition",
            "AMD RADEON 6900XT",
            "AMD RADEON 6800XT",
            "AMD RADEON 6800X",
            "AMD Ryzen 9 5950X",
            "AMD Ryzen 9 5900X",
            "AMD Ryzen 9 5800X",
            "AMD Ryzen 9 5600X"
        };

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
            _productsCollection.Insert(product);
        }

        public void Remove(Guid productId)
        {
            _productsCollection.Delete(productId);
        }

        public void RemoveAll()
        {
            _productsCollection.DeleteAll();
        }

        public void Update(Product product)
        {
            var productFromDB = _productsCollection.FindById(product.ProductId);
            if (productFromDB != null)
            {
                var updatedProduct = new Product
                {
                    ProductId = productFromDB.ProductId,
                    ProductDescription = product.ProductDescription ?? productFromDB.ProductDescription,
                    ProductName = product.ProductName ?? productFromDB.ProductName,
                    ProductImage = product.ProductImage ?? productFromDB.ProductImage,
                    ProductPrice = product.ProductPrice != productFromDB.ProductPrice ? product.ProductPrice : productFromDB.ProductPrice,
                    ProductSeller = product.ProductSeller ?? productFromDB.ProductSeller
                };

                _productsCollection.Update(updatedProduct);
            }
        }

        public void GenerateInitialProducts()
        {
            List<Product> products = new List<Product>();
            for(var i = 0; i < _defaultShops.Length; i++)
            {
                for (var j = 0; j < _defaultProductNames.Length; j++)
                {
                    var product = new Product
                    {
                        ProductId = Guid.NewGuid(),
                        ProductName = _defaultProductNames[j],
                        ProductPrice = _random.Next(0, 2000),
                        ProductDescription = "Default Product",
                        ProductSeller = _defaultShops[i]
                    };
                    products.Add(product);
                }
            }
            _productsCollection.InsertBulk(products);
        }
    }
}

using LinqKit;
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

        public Product Get(Guid productId)
        {
            var product = _productsCollection.FindById(productId);
            return product;
        }
        public void Add(Product product)
        {
            product.ProductId = Guid.NewGuid();
            product.Quantity = 1;
            _productsCollection.Insert(product);
        }

        public void Delete(Guid productId)
        {
            _productsCollection.Delete(productId);
        }

        public void DeleteAll()
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
                    ProductSeller = product.ProductSeller ?? productFromDB.ProductSeller,
                    Quantity = product.Quantity != productFromDB.Quantity ? product.Quantity : productFromDB.Quantity
                };

                _productsCollection.Update(updatedProduct);
            }
        }

        public void GenerateInitialProducts()
        {
            if (_productsCollection.Count() <= 0)
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
                            ProductSeller = _defaultShops[i],
                            Quantity = 1,
                        };
                        products.Add(product);
                    }
                }
                _productsCollection.InsertBulk(products);
            }
        }

        public List<Product> Search(
            Guid productId,
            string productName,
            string productSeller,
            string productDescription,
            decimal minPrice,
            decimal maxPrice)
        {

            var predicate = PredicateBuilder.New<Product>();

            if (productId != null)
            {
                predicate = predicate.Or(x => x.ProductId == productId);
            }

            if (productName != null)
            {
                predicate = predicate.Or(x => x.ProductName.Contains(productName));
            }

            if (productSeller != null)
            {
                predicate = predicate.Or(x => x.ProductSeller.Contains(productSeller));
            }
            
            if (productDescription != null)
            {
                predicate = predicate.Or(x => x.ProductDescription.Contains(productDescription));
            }

            if (minPrice != 0)
            {
                predicate = predicate.Or(x => x.ProductPrice >= minPrice);
            }
            
            if (maxPrice != 0)
            {
                predicate = predicate.Or(x => x.ProductPrice <= maxPrice);
            }

            var prods = _productsCollection.Find(predicate);

            return prods.ToList();
        }
    }
}

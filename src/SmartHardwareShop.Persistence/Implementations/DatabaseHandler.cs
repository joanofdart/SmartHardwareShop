using LiteDB;
using Microsoft.Extensions.Caching.Memory;
using SmartHardwareShop.Models;
using SmartHardwareShop.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHardwareShop.Persistence.Implementations
{
    class DatabaseHandler : IDatabase
    {
        private LiteDatabase _liteDatabase;
        private readonly ILiteCollection<Cart> _cartsCollection;
        private readonly ILiteCollection<Product> _productsCollection;
        private readonly ILiteCollection<News> _newsCollection;
        private readonly ILiteCollection<Order> _ordersCollection;

        public DatabaseHandler(ILiteDbContext liteDbContext)
        {
            _liteDatabase = liteDbContext.Database;
            _cartsCollection = _liteDatabase.GetCollection<Cart>("carts");
            _cartsCollection.EnsureIndex(x => x.CartId);
            _productsCollection = _liteDatabase.GetCollection<Product>("products");
            _productsCollection.EnsureIndex(x => x.ProductId);
            _newsCollection = _liteDatabase.GetCollection<News>("news");
            _newsCollection.EnsureIndex(x => x.NewsId);
            _ordersCollection = _liteDatabase.GetCollection<Order>("orders");
            _ordersCollection.EnsureIndex(x => x.OrderId);
        }

        public Cart CreateCart(Cart cart)
        {
            cart.CartClosed = false;
            cart.CartId = Guid.NewGuid();
            cart.Products = new List<Product>();
            _cartsCollection.Insert(cart);
            return cart;
        }

        public void CloseCart(Guid cartId)
        {
            var cart = _cartsCollection.FindById(cartId);
            cart.CartClosed = true;
            _cartsCollection.Update(cart);
        }

        public Cart GetCardById(Guid cartId)
        {
            var cart = _cartsCollection.FindById(cartId);
            return cart;
        }

        public List<Product> GetCurrentProducts()
        {
            var list = _productsCollection.FindAll().ToList();
            return list;
        }

        public Product GetProductById(Guid productId)
        {
            var product = _productsCollection.FindById(productId);
            return product;
        }
        public void AddProduct(Product product)
        {
            product.ProductId = Guid.NewGuid();
            product.ProductImage = product.ProductImage ?? "https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png";
            _productsCollection.Insert(product);
        }

        public void RemoveProduct(Guid productId)
        {
            _productsCollection.Delete(productId);
        }

        public void UpdateProduct(Product product)
        {
            _productsCollection.Update(product);
        }

        public void AddNews(News news)
        {
            news.NewsId = Guid.NewGuid();
            _newsCollection.Insert(news);
        }

        public void RemoveNewsById(Guid newsId)
        {
            _newsCollection.Delete(newsId);
        }

        public void UpdateNews(News news)
        {
            _newsCollection.Update(news);
        }
    }
}

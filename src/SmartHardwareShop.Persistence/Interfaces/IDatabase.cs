using Microsoft.Extensions.Caching.Memory;
using SmartHardwareShop.Models;
using System;
using System.Collections.Generic;

namespace SmartHardwareShop.Persistence.Interfaces
{
    public interface IDatabase
    {
        Cart GetCardById(Guid cardId);
        Cart CreateCart(Cart cart);
        void CloseCart(Guid cartId);
        List<Product> GetCurrentProducts();
        Product GetProductById(Guid productId);
        void AddProduct(Product product);
        void RemoveProduct(Guid productId);
        void UpdateProduct(Product product);
        void AddNews(News news);
        void RemoveNewsById(Guid newsId);
        void UpdateNews(News news);
    }
}

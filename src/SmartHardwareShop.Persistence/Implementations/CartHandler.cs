using LiteDB;
using SmartHardwareShop.Models;
using SmartHardwareShop.Persistence.Interfaces;
using System;
using System.Collections.Generic;

namespace SmartHardwareShop.Persistence.Implementations
{
    class CartHandler : ICartHandler
    {
        private LiteDatabase _liteDatabase;
        private readonly ILiteCollection<Cart> _cartsCollection;

        public CartHandler(ILiteDbContext liteDbContext)
        {
            _liteDatabase = liteDbContext.Database;
            _cartsCollection = _liteDatabase.GetCollection<Cart>("carts");
            _cartsCollection.EnsureIndex(x => x.CartId);
        }

        public Cart Create(Cart cart)
        {
            cart.CartClosed = false;
            cart.CartId = Guid.NewGuid();
            cart.Products = new List<Product>();
            _cartsCollection.Insert(cart);
            return cart;
        }

        public Cart ById(Guid cartId)
        {
            var cart = _cartsCollection.FindById(cartId);
            return cart;
        }

        public void Close(Guid cartId)
        {
            var cart = _cartsCollection.FindById(cartId);
            cart.CartClosed = true;
            _cartsCollection.Update(cart);
        }
    }
}

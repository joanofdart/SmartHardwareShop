using LiteDB;
using SmartHardwareShop.Models;
using SmartHardwareShop.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHardwareShop.Persistence.Implementations
{
    class CartHandler : ICartHandler
    {
        private LiteDatabase _liteDatabase;
        private readonly ILiteCollection<Cart> _cartsCollection;
        private readonly IProductHandler _productHandler;

        public CartHandler(ILiteDbContext liteDbContext, IProductHandler productHandler)
        {
            _liteDatabase = liteDbContext.Database;
            _cartsCollection = _liteDatabase.GetCollection<Cart>("carts");
            _cartsCollection.EnsureIndex(x => x.CartId);
            _productHandler = productHandler;
        }

        public Cart Create(Cart cart)
        {
            cart.CartClosed = false;
            cart.CartId = Guid.NewGuid();
            cart.Products = new Dictionary<string, Product>();
            _cartsCollection.Insert(cart);
            return cart;
        }

        public Cart Get(Guid cartId)
        {
            var cart = _cartsCollection.FindById(cartId);
            return cart;
        }

        public List<Cart> GetAll()
        {
            var carts = _cartsCollection.FindAll().ToList();
            return carts;
        }

        public void Close(Guid cartId)
        {
            var cart = _cartsCollection.FindById(cartId);
            cart.CartClosed = true;
            _cartsCollection.Update(cart);
        }

        public void Open(Guid cartId)
        {
            var cart = _cartsCollection.FindById(cartId);
            cart.CartClosed = false;
            _cartsCollection.Update(cart);
        }

        public Cart AddProduct(Guid productId, Guid cartId)
        {
            var cart = _cartsCollection.FindById(cartId);
            var product = _productHandler.Get(productId);
            if (cart != null && product != null)
            {
                if (cart.Products.ContainsKey(product.ProductId.ToString()))
                {
                    cart.Products[product.ProductId.ToString()].Quantity += 1;
                } else
                {
                    cart.Products.Add(product.ProductId.ToString(), product);
                }
                cart.TotalPrice += product.ProductPrice;
                var updatedCart = new Cart {
                    CartId = cart.CartId,
                    CartClosed = cart.CartClosed,
                    Products = cart.Products,
                    TotalPrice = cart.TotalPrice
                };
                _cartsCollection.Update(updatedCart);
                return updatedCart;
            }
            return null;
        }

        public Cart DeleteProduct(Guid productId, Guid cartId)
        {
            var cart = _cartsCollection.FindById(cartId);
            var product = _productHandler.Get(productId);
            if (cart != null && product != null)
            {
                if (cart.Products.ContainsKey(product.ProductId.ToString()) && cart.Products[product.ProductId.ToString()].Quantity > 1)
                {
                    cart.Products[product.ProductId.ToString()].Quantity -= 1;
                }
                else
                {
                    cart.Products.Remove(product.ProductId.ToString());
                }

                if (cart.TotalPrice != 0)
                {
                    cart.TotalPrice -= product.ProductPrice;
                }
                var updatedCart = new Cart
                {
                    CartId = cart.CartId,
                    CartClosed = cart.CartClosed,
                    Products = cart.Products,
                    TotalPrice = cart.TotalPrice
                };
                _cartsCollection.Update(updatedCart);
                return updatedCart;
            }
            return null;
        }
    }
}

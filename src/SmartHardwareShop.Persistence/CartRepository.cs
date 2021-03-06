﻿using SmartHardwareShop.Interfaces.Repositories;
using SmartHardwareShop.Models;
using SmartHardwareShop.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHardwareShop.Persistence
{
    public class CartRepository : ICartRepository
    {
        private readonly ICartHandler _cartHandler;

        public CartRepository(ICartHandler cartHandler)
        {
            _cartHandler = cartHandler;
        }

        public async Task<Cart> Create()
        {
            return await Task.Run(() => {
                return _cartHandler.Create(new Cart());
            });
        }

        public async Task<Cart> Add(Guid productId, Guid cartId)
        {
            var _cartFromDB = await Task.Run(() => {
                return _cartHandler.AddProduct(productId, cartId);
            });

            return _cartFromDB;
        }

        public async Task<Cart> Delete(Guid productId, Guid cartId)
        {
            var _cartFromDB = await Task.Run(() => {
                return _cartHandler.DeleteProduct(productId, cartId);
            });

            return _cartFromDB;
        }

        public async Task<Cart> Get(Guid cartId)
        {
            var _cartFromDB = await Task.Run(() => {
                return _cartHandler.Get(cartId);
            });

            return _cartFromDB;
        }

        public async Task<List<Cart>> GetAll()
        {
            var _cartsFromDB = await Task.Run(() => {
                return _cartHandler.GetAll();
            });

            return _cartsFromDB;
        }

        public async Task Close(Guid cartId)
        {
            await Task.Run(() => {
                _cartHandler.Close(cartId);
            });
        }

        public async Task Open(Guid cartId)
        {
            await Task.Run(() => {
                _cartHandler.Open(cartId);
            });
        }
    }
}

﻿using SimpleInjector;
using SmartHardwareShop.Interfaces.Repositories;
using SmartHardwareShop.Persistence.Implementations;
using SmartHardwareShop.Persistence.Interfaces;

namespace SmartHardwareShop.Persistence
{
    public static class PersistenceAdapter
    {
        /// <summary>
        /// Creates an extension method on Container
        /// </summary>
        /// <param name="container"></param>
        public static void RegisterPersistence(this Container container) {
            container.Register<ICartRepository, CartRepository>();
            container.Register<IProductRepository, ProductRepository>();
            container.Register<INewsRepository, NewsRepository>();
            container.Register<ILiteDbContext, LiteDbContext>();
            container.Register<ICartHandler, CartHandler>();
            container.Register<IProductHandler, ProductHandler>();
            container.Register<INewsHandler, NewsHandler>();
        }
    }
}

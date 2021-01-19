using SimpleInjector;
using SmartHardwareShop.Interfaces.Repositories;
using SmartHardwareShop.Models;
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
            container.Register<IMemoryDatabase<Cart>, CartHandler>();
            container.Register<IMemoryDatabase<Product>, ProductHandler>();
        }
    }
}

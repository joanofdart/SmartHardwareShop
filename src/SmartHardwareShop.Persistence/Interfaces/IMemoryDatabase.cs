using Microsoft.Extensions.Caching.Memory;
using System;

namespace SmartHardwareShop.Persistence.Interfaces
{
    public interface IMemoryDatabase<T>
    {
        T GetItem(Guid key);
        T AddItem(T key);
        void RemoveItem(T key);
    }
}

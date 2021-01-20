using SmartHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHardwareShop.Interfaces.UseCases
{
    public interface IUpdateProduct
    {
        Task Update(Product product);
    }
}

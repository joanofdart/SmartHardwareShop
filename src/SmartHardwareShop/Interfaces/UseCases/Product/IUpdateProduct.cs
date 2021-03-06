﻿using SmartHardwareShop.Models;
using System.Threading.Tasks;

namespace SmartHardwareShop.Interfaces.UseCases
{
    public interface IUpdateProduct
    {
        Task Execute(Product product);
    }
}

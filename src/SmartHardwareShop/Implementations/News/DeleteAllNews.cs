using SmartHardwareShop.Interfaces.Repositories;
using SmartHardwareShop.Interfaces.UseCases;
using System;
using System.Threading.Tasks;

namespace SmartHardwareShop.Implementations
{
    public class DeleteAllNews : IDeleteAllNews
    {
        private readonly INewsRepository _newsRepository;

        public async Task Execute()
        {
            await _newsRepository.DeleteAll();
        }
    }
}




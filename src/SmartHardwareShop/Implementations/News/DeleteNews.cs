using SmartHardwareShop.Interfaces.Repositories;
using SmartHardwareShop.Interfaces.UseCases;
using System;
using System.Threading.Tasks;

namespace SmartHardwareShop.Implementations
{
    public class DeleteNews : IDeleteNews
    {
        private readonly INewsRepository _newsRepository;

        public DeleteNews(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task Execute(Guid newsId)
        {
            await _newsRepository.Delete(newsId);
        }
    }
}




using SmartHardwareShop.Interfaces.Repositories;
using SmartHardwareShop.Interfaces.UseCases;
using SmartHardwareShop.Models;
using System.Threading.Tasks;

namespace SmartHardwareShop.Implementations
{
    public class UpdateNews : IUpdateNews
    {
        private readonly INewsRepository _newsRepository;

        public UpdateNews(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task Execute(News news)
        {
            await _newsRepository.Update(news);
        }
    }
}




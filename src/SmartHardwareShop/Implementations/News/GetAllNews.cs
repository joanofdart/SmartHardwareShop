using SmartHardwareShop.Interfaces.Repositories;
using SmartHardwareShop.Interfaces.UseCases;
using SmartHardwareShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHardwareShop.Implementations
{
    public class GetAllNews : IGetAllNews
    {
        private readonly INewsRepository _newsRepository;

        public GetAllNews(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<List<News>> Execute()
        {
            var listOfProducts = await _newsRepository.GetAll();
            return listOfProducts;
        }
    }
}




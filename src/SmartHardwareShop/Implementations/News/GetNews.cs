using SmartHardwareShop.Interfaces.Repositories;
using SmartHardwareShop.Interfaces.UseCases;
using SmartHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHardwareShop.Implementations
{
    public class GetNews : IGetNews
    {
        private readonly INewsRepository _newsRepository;

        public GetNews(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<News> Execute(Guid newsId)
        {
            var newsFromDB = await _newsRepository.Get(newsId);
            return newsFromDB;
        }
    }
}




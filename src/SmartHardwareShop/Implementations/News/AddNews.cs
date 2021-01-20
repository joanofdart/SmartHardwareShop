using SmartHardwareShop.Interfaces.Repositories;
using SmartHardwareShop.Interfaces.UseCases;
using SmartHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHardwareShop.Implementations
{
    public class AddNews : IAddNews
    {
        private readonly INewsRepository _newsRepository;

        public AddNews(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task Execute(News news)
        {
            await _newsRepository.Add(news);
        }

    }
}




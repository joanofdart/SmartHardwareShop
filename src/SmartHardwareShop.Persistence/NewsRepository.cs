using SmartHardwareShop.Interfaces.Repositories;
using SmartHardwareShop.Models;
using SmartHardwareShop.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHardwareShop.Persistence
{
    public class NewsRepository : INewsRepository
    {
        private readonly INewsHandler _newsHandler;

        public NewsRepository(INewsHandler newsHandler)
        {
            _newsHandler = newsHandler;
        }

        public async Task<List<News>> GetAll()
        {
            var listOfNews = await Task.Run(() => {
                return _newsHandler.GetAll();
            });

            return listOfNews;
        }

        public async Task<News> Get(Guid newsId)
        {
            var newsFromDB = await Task.Run(() => {
                return _newsHandler.Get(newsId);
            });

            return newsFromDB;
        }

        public async Task Add(News news)
        {
            await Task.Run(() => {
                _newsHandler.Add(news);
            });
        }

        public async Task Delete(Guid newsId)
        {
            await Task.Run(() => {
                _newsHandler.Delete(newsId);
            });
        }

        public async Task DeleteAll()
        {
            await Task.Run(() => {
                _newsHandler.DeleteAll();
            });
        }

        public async Task Update(News news)
        {
            await Task.Run(() => {
                _newsHandler.Update(news);
            });
        }
    }
}

using LiteDB;
using SmartHardwareShop.Models;
using SmartHardwareShop.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHardwareShop.Persistence.Implementations
{
    class NewsHandler : INewsHandler
    {
        private readonly LiteDatabase _liteDatabase;
        private readonly ILiteCollection<News> _newsCollection;

        public NewsHandler(ILiteDbContext liteDbContext)
        {
            _liteDatabase = liteDbContext.Database;
            _newsCollection = _liteDatabase.GetCollection<News>("news");
            _newsCollection.EnsureIndex(x => x.NewsId);
        }

        public List<News> GetAll()
        {
            var list = _newsCollection.FindAll().ToList();
            return list;
        }

        public News Get(Guid productId)
        {
            var news = _newsCollection.FindById(productId);
            return news;
        }
        public void Add(News news)
        {
            news.NewsId = Guid.NewGuid();
            _newsCollection.Insert(news);
        }

        public void Delete(Guid newsId)
        {
            _newsCollection.Delete(newsId);
        }

        public void DeleteAll()
        {
            _newsCollection.DeleteAll();
        }

        public void Update(News news)
        {
            var newsFromDB = _newsCollection.FindById(news.NewsId);
            if (newsFromDB != null)
            {
                var updatedNews = new News
                {
                    NewsId = newsFromDB.NewsId,
                    NewsName = news.NewsName ?? newsFromDB.NewsName,
                    NewsBanner = news.NewsBanner ?? newsFromDB.NewsBanner,
                    NewsContent = news.NewsContent ?? newsFromDB.NewsContent,

                };

                _newsCollection.Update(updatedNews);
            }
        }
    }
}

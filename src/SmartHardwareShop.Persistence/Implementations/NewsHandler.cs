using LiteDB;
using SmartHardwareShop.Models;
using SmartHardwareShop.Persistence.Interfaces;
using System;

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
        public void Add(News news)
        {
            news.NewsId = Guid.NewGuid();
            _newsCollection.Insert(news);
        }

        public void Remove(Guid newsId)
        {
            _newsCollection.Delete(newsId);
        }

        public void Update(News news)
        {
            _newsCollection.Update(news);
        }
    }
}

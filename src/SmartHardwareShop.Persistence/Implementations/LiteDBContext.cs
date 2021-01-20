using LiteDB;
using Microsoft.Extensions.Options;
using SmartHardwareShop.Persistence.Interfaces;

namespace SmartHardwareShop.Persistence.Implementations
{
    public class LiteDbContext : ILiteDbContext
    {
        public LiteDatabase Database { get; }

        public class LiteDbOptions
        {
            public string ConnectionString { get; set; }
        }

        public LiteDbContext(IOptions<LiteDbOptions> options)
        {
            Database = new LiteDatabase(options.Value.ConnectionString);
        }
    }
}

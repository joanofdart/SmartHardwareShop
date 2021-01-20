using LiteDB;

namespace SmartHardwareShop.Persistence.Interfaces
{
    public interface ILiteDbContext
    {
        LiteDatabase Database { get; }
    }
}

using System.Data;

namespace ShopBridge.Repository.Interfaces
{
    public interface IDBConnectionFactory
    {
        IDbConnection CreateShopBridgeDBConnection();
    }
}

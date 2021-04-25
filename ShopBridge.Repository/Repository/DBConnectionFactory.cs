using ShopBridge.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ShopBridge.Repository.Repository
{
   public class DBConnectionFactory : IDBConnectionFactory
    {
        private readonly IRepositoryConfiguration _repositoryConfiguration;

        public DBConnectionFactory(IRepositoryConfiguration repositoryConfiguration)
        {
            this._repositoryConfiguration = repositoryConfiguration;
        }
        public IDbConnection CreateShopBridgeDBConnection()
        {
            var conn = new SqlConnection(_repositoryConfiguration.GetDBConnectionString());
            conn.Open();
            return conn;
        }
    }
}

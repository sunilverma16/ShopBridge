using ShopBridge.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridge.Repository.Repository
{
    public class RepositoryConfiguration : IRepositoryConfiguration
    {
        private readonly string _connectionString;
        public RepositoryConfiguration(string shopBridgeConnectionString)
        {
            _connectionString = shopBridgeConnectionString;
        }

        public string GetDBConnectionString()
        {
            return _connectionString;
        }
    }
}

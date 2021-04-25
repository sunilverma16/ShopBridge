using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridge.Repository.Interfaces
{
    public interface IRepositoryConfiguration
    {
        string GetDBConnectionString();
    }
}

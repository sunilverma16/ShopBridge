using Microsoft.Extensions.DependencyInjection;
using ShopBridge.Repository.Interfaces;
using ShopBridge.Repository.Repository;
using System;

namespace ShopBridge.Repository.Ioc
{
    public static class ContainerExtension
    {

        public static void RegisterRepositories(this IServiceCollection services, string dbConnectionString)
        {
            if (string.IsNullOrEmpty(dbConnectionString))
            {
                throw new Exception("Database connection string is not set.");
            }

            services.AddSingleton<IRepositoryConfiguration>(new RepositoryConfiguration(dbConnectionString));
            services.AddScoped<IDBConnectionFactory, DBConnectionFactory>();
            services.AddScoped<IProductRepository, ProductRepository>();

        }       
    }
}

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ShopBridge.Repository.Ioc;
using ShopBridge.Service.Interfaces;
using ShopBridge.Service.Services;

namespace ShopBridge.Service.Ioc
{
    public static class ContainerExtension
    {
        public static void RegisterServices(this IServiceCollection services, string dbConnectionString)
        {
            services.RegisterRepositories(dbConnectionString);
            services.AddScoped<IProductService, ProductService>();
        }
    }
}

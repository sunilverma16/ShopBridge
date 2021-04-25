using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ShopBridge.Repository.Interfaces;
using ShopBridge.Shared.Models;
using Dapper;
using System.Threading.Tasks;
using System.Linq;

namespace ShopBridge.Repository.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDBConnectionFactory dBConnectionFactory;
        private readonly string deleteQuery = $"Delete from product where productid = @id";

        public ProductRepository(IDBConnectionFactory connectionFactory)
        {
            this.dBConnectionFactory = connectionFactory;
        }

        public async Task<int> Delete(int productId)
        {
            using IDbConnection dbConnection = dBConnectionFactory.CreateShopBridgeDBConnection();
            var product = await dbConnection.QueryAsync(deleteQuery, new { Id = productId },
                commandType: CommandType.Text).ConfigureAwait(false);

            return productId;
        }

        public async Task<List<Product>> GetAll()
        {
            using IDbConnection dbConnection = dBConnectionFactory.CreateShopBridgeDBConnection();
            var products = await dbConnection.QueryAsync<Product>(
                "GetAllProduct",
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);

            return products.ToList();
        }

        public async Task<int> Save(Product product)
        {
            //TODO: save and return id
            using IDbConnection dBConnection = dBConnectionFactory.CreateShopBridgeDBConnection();
            var productIds = await dBConnection.QueryAsync<int>("InsertProduct",
                new
                {
                    @Name = product.Name,
                    @Description = product.Description,
                    @Price = product.Price,
                    @ProductCode = product.ProductCode,
                    @Brand = product.Brand,
                    @CountryOfOrigin = product.CountryOfOrigin
                }, commandType: CommandType.StoredProcedure).ConfigureAwait(false);

            

            return productIds.ToList().FirstOrDefault();
        }

        public async Task<int> Update(Product product)
        {
            using IDbConnection dBConnection = dBConnectionFactory.CreateShopBridgeDBConnection();
            var productIds = await dBConnection.QueryAsync<int>("UpdateProduct",
                new
                {
                    @Name = product.Name,
                    @Description = product.Description,
                    @Price = product.Price,
                    @ProductCode = product.ProductCode,
                    @Brand = product.Brand,
                    @CountryOfOrigin = product.CountryOfOrigin
                }, commandType: CommandType.StoredProcedure).ConfigureAwait(false);



            return productIds.ToList().FirstOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShopBridge.Shared.Models;

namespace ShopBridge.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<int> Save(Product product);
        Task<int> Update(Product product);
        Task<int> Delete(int productId);
        Task<List<Product>> GetAll();


    }
}

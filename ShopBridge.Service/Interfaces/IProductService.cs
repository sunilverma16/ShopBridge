using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShopBridge.Shared.Models;

namespace ShopBridge.Service.Interfaces
{
    public interface IProductService
    {
        Task<ApiResponse<int>> Save(Product product);
        Task<ApiResponse<int>> Update(Product product);
        Task<ApiResponse<int>> Delete(int productId);
        Task<ApiResponse<List<Product>>> GetAll();

    }
}

using ShopBridge.Service.Interfaces;
using ShopBridge.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ShopBridge.Repository.Interfaces;
using ShopBridge.Repository.Repository;
using ShopBridge.Shared.Constants;
using System.Threading.Tasks;

namespace ShopBridge.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<ApiResponse<int>> Save(Product product)
        {
            var productId =await productRepository.Save(product);
            if (productId > 0)
            {
                return new ApiResponse<int>(ApiStatusCode.Ok)
                {
                    Data = productId
                };
            }
            else
            {
                return new ApiResponse<int>(ApiStatusCode.Error)
                {
                    Data = 0
                };
            }

        }

        public async Task<ApiResponse<int>> Update(Product product)
        {
            var productId = await productRepository.Update(product);
            if (productId > 0)
            {
                return new ApiResponse<int>(ApiStatusCode.Ok)
                {
                    Data = productId
                };
            }
            else
            {
                return new ApiResponse<int>(ApiStatusCode.Error)
                {
                    Data = product.ProductID
                };
            };
        }

        public async Task<ApiResponse<int>> Delete(int productId)
        {
            var deletedProductId = await productRepository.Delete(productId);
            if (deletedProductId > 0)
            {
                return new ApiResponse<int>(ApiStatusCode.Ok)
                {
                    Data = deletedProductId
                };
            }
            else
            {
                return new ApiResponse<int>(ApiStatusCode.Error)
                {
                    Data = productId
                };
            }

        }

        public async Task<ApiResponse<List<Product>>> GetAll()
        {
            List<Product> products = await productRepository.GetAll();
            if (products != null && products.Count > 0)
            {
                return new ApiResponse<List<Product>>(ApiStatusCode.Ok)
                {
                    Data = products
                };
            }
            else
            {
                return new ApiResponse<List<Product>>(ApiStatusCode.Ok)
                {
                    Message = ConstantString.RecordNotFound
                };
            }
        }
    }
}


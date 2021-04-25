using Microsoft.AspNetCore.Mvc;
using ShopBridge.Service.Interfaces;
using ShopBridge.Shared.Constants;
using ShopBridge.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;

        }

        [HttpPost]
        [Route("Insert")]
        public async Task<ApiResponse<int>> Insert([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                return await productService.Save(product);
            }
            else
            {
                return new ApiResponse<int>(ApiStatusCode.ValidationError)
                {
                    Data = 0
                };
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ApiResponse<int>> Update([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                return await productService.Update(product);

            }
            else
            {
                return new ApiResponse<int>(ApiStatusCode.ValidationError)
                {
                    Data = product.ProductID
                };
            }

        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ApiResponse<int>> Delete([FromBody] int productId)
        {
            if (ModelState.IsValid)
            {
                return await productService.Delete(productId);

            }
            else
            {
                return new ApiResponse<int>(ApiStatusCode.ValidationError)
                {
                    Data = productId
                };
            }

        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ApiResponse<List<Product>>> GetAll()
        {
            return await productService.GetAll();
        }
    }
}

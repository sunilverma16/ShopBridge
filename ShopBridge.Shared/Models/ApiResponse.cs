using ShopBridge.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridge.Shared.Models
{
    public class ApiResponse<T>
    {
        public ApiStatusCode StatusCode { get; set; }
        public string Message { get; set; }

        public T Data { get; set; }

        public ApiResponse(ApiStatusCode apiStatusCode)
        {

            StatusCode = ApiStatusCode.Ok;
            switch (apiStatusCode)
            {
                case ApiStatusCode.Ok:
                    Message = ConstantString.SuccessMessage;
                    break;
                case ApiStatusCode.ValidationError:
                    Message = ConstantString.ValidationMessage;
                    break;
                case ApiStatusCode.Error:
                    Message = ConstantString.ErrorMessage;
                    break;

            }
        }

        public ApiResponse() { }
    }
}
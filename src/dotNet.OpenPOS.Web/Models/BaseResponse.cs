using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet.OpenPOS.Web.Models
{
    public class BaseResponse
    {
        public BaseResponse(bool success, object data, string message)
        {
            Success = success;
            Data = data;
            Message = message;
        }

        public bool Success { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}

using dotNet.OpenPOS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet.OpenPOS.Validation
{
    public class OrderValidationHelper
    {
        public OrderValidationHelper()
        {
        }

        public Models.Validation ValidateOnPost(Order item)
        {
            var result = new Models.Validation();

            //TODO...

            result.Valid = true;
            return result;
        }
    }
}

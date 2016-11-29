using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet.OpenPOS.Validation.Extensions
{
    public static class ValidationExtensions
    {
        public static bool IsValid(this Models.Validation validation)
        {
            return validation.Valid;
        }
    }
}

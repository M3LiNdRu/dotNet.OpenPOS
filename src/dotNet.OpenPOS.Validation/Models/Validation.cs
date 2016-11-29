using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet.OpenPOS.Validation.Models
{
    public class Validation
    {
        public bool Valid { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
}


using System.Collections.Generic;

namespace dotNet.OpenPOS.Web.Models
{
    public class ApplicationConfigurationOptions
    {
        public IDictionary<string,string> ConnectionStrings { get; set; }
        public Logging Logging { get; set; }
    }

    public class Logging
    {
        public bool IncludeScopes { get; set; }
        public string LogLevel { get; set; }
    }
}

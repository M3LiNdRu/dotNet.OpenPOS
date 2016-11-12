using dotNet.OpenPOS.Domain.Models;


namespace dotNet.OpenPOS.Web.Models
{
    public class InitializeViewModel
    {
        public DatabaseConnectionConfig Config { get; set; }
        public Account Account { get; set; }
        //TODO: Add Product/ProductFamily/Tax property for setting them
    }
}

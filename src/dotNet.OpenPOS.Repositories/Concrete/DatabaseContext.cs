using dotNet.OpenPOS.Repositories.Interfaces;

namespace dotNet.OpenPOS.Repositories.Concrete
{
    public class DatabaseContext : IDatabaseContext
    {
        public DatabaseContext() { }
        public DatabaseContext(string connectionName) { }
    }
}


using dotNet.OpenPOS.Domain.Models;
using System.Data.SqlClient;

namespace dotNet.OpenPOS.Web.Helpers
{
    public static class DatabaseConnectionConfigHelper
    {
        public static string BuildConnectionString(this DatabaseConnectionConfig config)
        {
            var builder = new SqlConnectionStringBuilder()
            {
                ConnectionString = config.DataBaseName
            };

            return builder.ConnectionString;
        }
    }
}

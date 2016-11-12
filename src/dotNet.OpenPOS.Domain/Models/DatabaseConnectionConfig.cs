using System;

namespace dotNet.OpenPOS.Domain.Models
{
    public class DatabaseConnectionConfig
    {
        public int Id { get; set; }
        public string ServerName { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DataBaseName { get; set; }
        public DateTime TIMESTAMP { get; set; }
    }
}

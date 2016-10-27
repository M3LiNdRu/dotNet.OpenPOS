
using System;

namespace dotNet.OpenPOS.Domain
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime TIMESTAMP { get; set; }
    }
}

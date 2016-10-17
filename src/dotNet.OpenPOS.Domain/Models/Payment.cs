
namespace dotNet.OpenPOS.Domain.Models
{
    public class Payment : IEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PaymentType { get; set; }
        public double Value { get; set; }
        public double ReturnValue { get; set; }
    }
}

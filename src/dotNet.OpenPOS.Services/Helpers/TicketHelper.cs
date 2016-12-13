using dotNet.OpenPOS.Domain.Models;
using dotNet.OpenPOS.Services.Models;
using System.Collections.Generic;

namespace dotNet.OpenPOS.Services.Helpers
{
    public static class TicketHelper
    {
        public static void Generate(this Ticket ticket, Account account, Order order, IEnumerable<Payment> payments)
        {
            ticket.AccountDetails = account;
            ticket.OrderDetails = order;
            ticket.PaymentDetails = payments;
        }
    }
}

using dotNet.OpenPOS.Repositories.Interfaces;
using dotNet.OpenPOS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNet.OpenPOS.Domain.Models;
using dotNet.OpenPOS.Services.Helpers;
using dotNet.OpenPOS.Services.Models;

namespace dotNet.OpenPOS.Services.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderReferenceRepository _referenceRepository;
        private readonly IProductRepository _productRepository;
        private readonly ITaxRepository _taxRepository;
        private readonly OrderHelper _orderHelper;
        private readonly IAccountRepository _accountRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPrintedTicketRepository _printedTicketRepository;

        public OrderService(IOrderRepository orderRepository, IOrderReferenceRepository referenceRepository,
            IProductRepository productRepository, ITaxRepository taxRepository, 
            IAccountRepository accountRepository, IPaymentRepository paymentRepository, IPrintedTicketRepository printedTicketRepository)
        {
            _orderRepository = orderRepository;
            _referenceRepository = referenceRepository;
            _productRepository = productRepository;
            _taxRepository = taxRepository;
            _orderHelper = new OrderHelper();
            _accountRepository = accountRepository;
            _paymentRepository = paymentRepository;
            _printedTicketRepository = printedTicketRepository;
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            return await _orderRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Order>> GetDailyOrdersAsync()
        {
            return await _orderRepository.GetDailyOrders();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.FindByIdAsync(id);
        }

        public async Task<bool> CreateOrderAsync(Order entity)
        {
            //1. Generate Reference
            entity.Reference = await _referenceRepository.GetOrderReferenceAsync();

            //2. Calculate product prices
            var products = await _productRepository.FindByIdAsync(entity.Products.Select(p => p.Id));
            var taxes = await _taxRepository.GetAllAsync();
            _orderHelper.UpdateOrderProducts(entity, products, taxes);

            //3. Calculate totals
            _orderHelper.UpdateOrderTotals(entity);

            entity.CreatedDate = DateTime.UtcNow;
            entity.TIMESTAMP = DateTime.UtcNow;
            entity.Status = Domain.Enums.OrderStatusType.Open;
            
            //4.Insert
            return await _orderRepository.InsertAsync(entity);
        }

        public async Task<bool> UpdateOrderAsync(Order entity)
        {
            return await _orderRepository.UpdateAsync(entity);
        }

        public async Task<Ticket> GetTicketByOrderIdAsync(int id)
        {
            var ticket = new Ticket();

            var order = await _orderRepository.FindByIdAsync(id);
            var account = await _accountRepository.GetAsync();
            var payments = await _paymentRepository.FindByOrderIdAsync(order.Id);

            TicketHelper.Generate(ticket, account, order, payments);
            
            return ticket;
        }

        public async Task<bool> SavePrintedTicketAsync(string printedTicket)
        {
            var entity = new PrintedTicket();
            entity.Ticket = printedTicket;
            entity.TIMESTAMP = DateTime.UtcNow;

            return await _printedTicketRepository.InsertAsync(entity);
        }
    }
}

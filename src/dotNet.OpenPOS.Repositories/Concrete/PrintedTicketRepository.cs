using dotNet.OpenPOS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNet.OpenPOS.Domain.Models;

namespace dotNet.OpenPOS.Repositories.Concrete
{
    public class PrintedTicketRepository : IPrintedTicketRepository
    {
        private readonly IDatabaseContext _context;

        public PrintedTicketRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = _context.Tickets.FirstOrDefault(x => x.Id == id);

            return _context.Tickets.Remove(entity);
        }

        public async Task<PrintedTicket> FindByIdAsync(int id)
        {
            return _context.Tickets.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<PrintedTicket>> GetAllAsync()
        {
            return _context.Tickets;
        }

        public async Task<bool> InsertAsync(PrintedTicket entity)
        {
            return _context.Tickets.Add(entity);
        }

        public async Task<bool> UpdateAsync(PrintedTicket entity)
        {
            _context.Tickets.Remove(entity);

            return _context.Tickets.Add(entity);
        }
    }
}

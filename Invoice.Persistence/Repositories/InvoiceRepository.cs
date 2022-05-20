using Microsoft.EntityFrameworkCore;
using Invoice.Application.Contracts;
using Invoice.Domain;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Persistence.Repositories
{
    public class InvoiceRepository : BaseRepository<Invoicee>, IInvoiceRepository
    {
        public InvoiceRepository(InvoiceDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<Guid> CreatInvoiceeAsync(Guid OrderId)
        {
            var order = await _dbContext.Orders.Include(o=>o.OrderProducts).FirstOrDefaultAsync(o => o.Id == OrderId);
            var tc = 0;
            var tp = 0;
            foreach (var Ord in order.OrderProducts)
            {
                var product =await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == Ord.ProductId);
                tc++;
                tp += product.Price;

            }
            Invoicee inv = new Invoicee
            {
                Id = Guid.NewGuid(),
                TotalCount = tc,
                TotalPrice = tp,
            };
            await _dbContext.Invoices.AddAsync(inv);
            await _dbContext.SaveChangesAsync();
            return inv.Id;
        }

        public Task<Invoicee> GetInvoiceeByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

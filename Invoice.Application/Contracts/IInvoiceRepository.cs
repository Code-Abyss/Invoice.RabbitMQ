using System;
using System.Collections.Generic;
using Invoice.Domain;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Contracts
{
    public interface IInvoiceRepository : IAsyncRepository<Invoicee>
    {
        Task<Invoicee> GetInvoiceeByIdAsync(Guid id);
        Task<Guid> CreatInvoiceeAsync(Guid OrderId);
    }
}

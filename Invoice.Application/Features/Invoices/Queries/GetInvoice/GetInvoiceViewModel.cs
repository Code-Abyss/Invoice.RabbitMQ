using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice.Application.Features.Invoices.Queries.GetInvoice
{
    public class GetInvoiceViewModel
    {
        public Guid Id { get; set; }
        public int totalPrice { get; set; }
        public int totalCount { get; set; }
    }
}

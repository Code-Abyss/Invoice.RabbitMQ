using Invoice.Application.Features.Invoices.Queries.GetInvoice;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice.Application.Features.Invoices.Queries.GetInvoice
{
    public class GetInvoiceQuery : IRequest<GetInvoiceViewModel>
    {
        public Guid Id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
namespace Invoice.Application.Features.Invoices.Commands
{
    public class CreateInvoiceCommand:IRequest<Guid>
    {
        public Guid OrderId { get; set; }

    }
}

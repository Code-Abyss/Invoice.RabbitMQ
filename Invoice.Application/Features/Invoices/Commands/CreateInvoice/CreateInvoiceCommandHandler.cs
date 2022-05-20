using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using AutoMapper;
using System.Threading.Tasks;
using System.Threading;
using Invoice.Application.Contracts;
using Invoice.Domain;
using Invoice.Application.Services.RabbitMQ.Producer;

namespace Invoice.Application.Features.Invoices.Commands
{
    public class CreateInvoiceCommandHandler:IRequestHandler<CreateInvoiceCommand,Guid>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        

        public CreateInvoiceCommandHandler(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository=invoiceRepository;


        }

        public async Task<Guid> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            
            var invoiceId=await _invoiceRepository.CreatInvoiceeAsync(request.OrderId);
            
            return invoiceId;
        }
    }
}

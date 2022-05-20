using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Invoice.Application.Contracts;
using MediatR;

namespace Invoice.Application.Features.Invoices.Queries.GetInvoice
{
    public class GetInvoiceQueryHandler: IRequestHandler<GetInvoiceQuery, GetInvoiceViewModel>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;
        
        public GetInvoiceQueryHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public async Task<GetInvoiceViewModel> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
        {
            var invoice = await _invoiceRepository.GetInvoiceeByIdAsync(request.Id);
            return _mapper.Map<GetInvoiceViewModel>(invoice);
        }
    }
}

using Invoice.Application.Features.Invoices.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Invoice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvoiceController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("AddInvoice", Name = "AddInvoice")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateInvoiceCommand createInvoiceCommand)
        {
            Guid id = await _mediator.Send(createInvoiceCommand);
            return Ok(id);
        }
    }
}

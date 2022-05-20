using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
namespace Invoice.Application.Features.Invoices.Commands
{
    public class CreateInvoiceCommandValidator:AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceCommandValidator()
        {
            RuleFor(p => p.OrderId).NotEmpty().NotNull();
      
        }
    }
}

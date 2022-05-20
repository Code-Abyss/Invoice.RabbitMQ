using AutoMapper;
using Invoice.Application.Features.Invoices.Commands;
using Invoice.Application.Features.Invoices.Queries.GetInvoice;
using Invoice.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Invoicee, CreateInvoiceCommand>().ReverseMap();
            CreateMap<Invoicee, GetInvoiceViewModel>().ReverseMap();
        }
    }
}

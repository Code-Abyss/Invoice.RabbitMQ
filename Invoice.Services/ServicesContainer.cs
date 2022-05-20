using FluentValidation;
using Invoice.Application.Features.Invoices.Commands;
using Invoice.Services.RabbitMQ.Producer;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Invoice.Services
{
    public static class ServicesContainer
    {
        public static IServiceCollection AddServicesServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}


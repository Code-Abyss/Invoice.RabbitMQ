using FluentValidation;
using Invoice.Application.Features.Invoices.Commands;
using Invoice.Application.Services.RabbitMQ;
using Invoice.Application.Services.RabbitMQ.Producer;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Invoice.Application
{
    public static class ApplicationContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddHostedService<Counsumer>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IValidator<CreateInvoiceCommand>, CreateInvoiceCommandValidator>();
            services.AddSingleton<IMessageProducer, RabbitMQProducer>();

            return services;
        }
    }
}


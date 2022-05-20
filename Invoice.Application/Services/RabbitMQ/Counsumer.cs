using Invoice.Application.Features.Invoices.Commands;
using Invoice.Application.Services.RabbitMQ.Producer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Invoice.Application.Services.RabbitMQ
{

    public class Counsumer: BackgroundService
    {

        private readonly IMediator mediator;
        private readonly IMessageProducer MessageProducer;
        public Counsumer(IMediator _mediator, IMessageProducer _producer)
        {
            mediator = _mediator;
            MessageProducer = _producer;
        }

        //public static void StartCounsumer()
        //{
        //    var factory = new ConnectionFactory
        //    {
        //        HostName = "localhost",
        //        UserName ="admin",
        //        Password ="123456"
        //    };
        //    var connection = factory.CreateConnection();
        //    var channel = connection.CreateModel();
        //    channel.QueueDeclare(queue:"orders", exclusive: false, durable: false, autoDelete: false, arguments: null);

        //    var consumer = new EventingBasicConsumer(channel);
        //    consumer.Received += async (model, eventArgs) =>
        //    {
        //        var body = eventArgs.Body.ToArray();
        //        var message = Encoding.UTF8.GetString(body);

        //        string x= JsonConvert.DeserializeObject(message).ToString();
        //        Console.WriteLine($"Message received: {x.ToUpper()}");
        //        CreateInvoiceCommand cic = new CreateInvoiceCommand
        //        {
        //            OrderId =new Guid(x)
        //        };
        //        Guid id = await mediator.Send(cic);
               

        //    };

        //    channel.BasicConsume(queue: "orders", autoAck: true, consumer: consumer);

        //}

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
           
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName ="admin",
                Password ="123456"
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue:"orders", exclusive: false, durable: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                string x= JsonConvert.DeserializeObject(message).ToString();
                Console.WriteLine($"Message received: {x.ToUpper()} From System.RabbitMQ");
                CreateInvoiceCommand cic = new CreateInvoiceCommand
                {
                    OrderId =new Guid(x)
                };
                Guid id = await mediator.Send(cic);
                MessageProducer.SendMessage<Guid>(id);
               

            };

            channel.BasicConsume(queue: "orders", autoAck: true, consumer: consumer);
            return Task.CompletedTask;
        }
    }
}

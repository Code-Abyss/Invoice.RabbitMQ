using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice.Application.Services.RabbitMQ.Producer
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}

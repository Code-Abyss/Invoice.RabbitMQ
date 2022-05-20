using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice.Domain
{
    public class Order
    {

        public Order()
        {
            this.OrderProducts = new List<OrderProduct>();
        }
        public Guid Id { get; set; }

        public OrderType Type { get; set; }

        public virtual List<OrderProduct> OrderProducts { get; set; }
    }
}

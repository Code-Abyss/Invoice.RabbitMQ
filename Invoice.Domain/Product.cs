using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice.Domain
{
    public class Product
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

    }
}

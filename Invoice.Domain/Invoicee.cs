using System;

namespace Invoice.Domain
{
    public class Invoicee
    {
        public Guid Id { get; set; }
        public int TotalPrice { get; set; } 
        public int TotalCount { get; set; }
    }
}

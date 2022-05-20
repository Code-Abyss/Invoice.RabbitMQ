using Microsoft.EntityFrameworkCore;
using System;
using Invoice.Domain;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;

namespace Invoice.Persistence
{
    public class InvoiceDBContext : DbContext
    {
        public DbSet<Invoicee> Invoices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public InvoiceDBContext(DbContextOptions<InvoiceDBContext> options) : base(options)
        {

        }

        
    }
    public class InvoiceContextFactory : IDesignTimeDbContextFactory<InvoiceDBContext>
    {
        public InvoiceDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InvoiceDBContext>();
            optionsBuilder.UseSqlServer("server=localhost;Initial catalog=RabbitMQ;integrated security=true");

            return new InvoiceDBContext(optionsBuilder.Options);
        }
    }
}

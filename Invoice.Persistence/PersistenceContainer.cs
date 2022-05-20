using Invoice.Application.Contracts;
using Invoice.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Invoice.Persistence
{
    public static class PersistenceContainer
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InvoiceDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IInvoiceRepository), typeof(InvoiceRepository));


            return services;
        }
    }
}

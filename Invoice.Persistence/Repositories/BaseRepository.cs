using Microsoft.EntityFrameworkCore;
using Invoice.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Persistence.Repositories
{
    public partial class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly InvoiceDBContext _dbContext;

        public BaseRepository(InvoiceDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}

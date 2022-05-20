using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Contracts
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
    }
}

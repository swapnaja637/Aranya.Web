using Aranya.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aranya.Application.Generic.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeproperties = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, string includeproperties = null);
        bool Add(T entity);
        bool Delete(T entity);
        bool Save();
    }
}

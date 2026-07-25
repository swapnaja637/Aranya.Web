using Aranya.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aranya.Application.Generic.Interfaces
{
   public  interface IVillaRepository : IRepository<Villa>
    {
     //  Task<IEnumerable<Villa>> GetAllAsync(Expression<Func<Villa,bool>>? filter=null, string? includeproperties=null );
     //Task<Villa> GetAsync(Expression<Func<Villa, bool>> filter , string includeproperties=null );
     //   bool Add(Villa entity);
        bool Update(Villa entity);
       // bool Delete(Villa entity);
        bool Save();
    }
}

using Aranya.Application.Generic.Interfaces;
using Aranya.Domain.Entities;
using Aranya.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Aranya.Infrastructure.Repository
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private readonly ApplicationDBContext _context;
        public VillaRepository(ApplicationDBContext context) : base(context) 
        {
            _context = context;
        }
        //public bool Add(Villa entity)
        //{
        //    try
        //    {
        //        _context.Add(entity);
        //        _context.SaveChanges();
        //        return true;

        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception or handle it as needed
        //        return false;
        //    }
        //}

        //public bool Delete(Villa entity)
        //{
        //    try
        //    {
        //        _context.Remove(entity);
        //        _context.SaveChanges();
        //        return true;

        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception or handle it as needed
        //        return false;
        //    }
        //}


    
        //public async Task<Villa> GetAsync(Expression<Func<Villa, bool>> filter, string includeproperties=null )
        //{
        //    try
        //    {
        //        IQueryable<Villa> query = _context.Set<Villa>();
        //        if (filter != null)
        //        {
        //            query = query.Where(filter);
        //        }
        //        if (!string.IsNullOrEmpty(includeproperties))
        //        {
        //            foreach (var includeprop in includeproperties.
        //                Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //            {
        //                query = query.Include(includeprop);
        //            }
        //        }
        //        return await query.FirstOrDefaultAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public bool Save()
        //{
        //    try
        //    {
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw;
                
        //    }
        //}

        public bool Update(Villa entity)
        {
            try
            {
                _context.Tbl_Villas.Update(entity);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

      //public async Task<IEnumerable<Villa>> GetAllAsync(Expression<Func<Villa, bool>>? filter, string? includeproperties)
      //  {
      //      try
      //      {
      //          IQueryable<Villa> Qry = _context.Set<Villa>();
      //          if (filter != null)
      //          {
      //              Qry = Qry.Where(filter);
      //          }
      //          if (!string.IsNullOrEmpty(includeproperties))
      //          {
      //              foreach (var includeprop in includeproperties.
      //                  Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
      //              {
      //                  Qry = Qry.Include(includeprop);
      //              }
      //          }
      //          return await Qry.ToListAsync();
      //      }
      //      catch(Exception ex)
      //      {
      //          throw;
      //      }
      //  }
    }
}

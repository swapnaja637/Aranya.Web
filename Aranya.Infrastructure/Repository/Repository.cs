using Aranya.Application.Generic.Interfaces;
using Aranya.Domain.Entities;
using Aranya.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aranya.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDBContext _context;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDBContext context)
        {
            _context = context;
         dbSet = _context.Set<T>();
        }

        public bool Add(T entity)
        {
            try
            {
                dbSet.Add(entity);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Any(Expression<Func<T, bool>> filter)
        {
            try
            {
                return await dbSet.AnyAsync(filter);

            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                _context.Remove(entity);
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeproperties = null)
        {
            try
            {
                IQueryable<T> Qry = dbSet;
                if (filter != null)
                {
                    Qry = Qry.Where(filter);
                }
                if (!string.IsNullOrEmpty(includeproperties))
                {
                    foreach (var includeprop in includeproperties.
                        Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        Qry = Qry.Include(includeprop);
                    }
                }
                return await  Qry.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, string includeproperties = null)
        {
            try
            {
                IQueryable<T> query = dbSet;
                if (filter != null)
                {
                    query = query.Where(filter);
                }
                if (!string.IsNullOrEmpty(includeproperties))
                {
                    foreach (var includeprop in includeproperties.
                        Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeprop);
                    }
                }
                return await query.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Save()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}

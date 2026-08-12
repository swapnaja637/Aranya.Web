using Aranya.Application.Generic.Interfaces;
using Aranya.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aranya.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        public IVillaRepository villa {  get; set; }

        public IVillaNumber villaNumber { get;set;  }

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
            villa = new VillaRepository(_context);
            villaNumber = new VillaNumberRepository(_context);
        }

        public async Task<bool> Save()
        {
            try
            {
               await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                    throw;
            }
        }
    }
}

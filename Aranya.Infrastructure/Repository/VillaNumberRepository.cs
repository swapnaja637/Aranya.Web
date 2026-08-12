using Aranya.Application.Generic.Interfaces;
using Aranya.Domain.Entities;
using Aranya.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aranya.Infrastructure.Repository
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumber
    {
        private readonly ApplicationDBContext _db;

        public VillaNumberRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }
        Task<bool> update(VillaNumber entity)
        {
            try
            {
                _db.Tbl_VillaNumber.Update(entity);
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

        Task<bool> IVillaNumber.update(VillaNumber entity)
        {
            return update(entity);
        }
    }

}

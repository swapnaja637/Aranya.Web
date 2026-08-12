using Aranya.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aranya.Application.Generic.Interfaces
{
    public interface IVillaNumber  : IRepository<VillaNumber>
    {
         Task<bool> update(VillaNumber entity);
    }
}

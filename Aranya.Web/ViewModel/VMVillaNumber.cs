using Aranya.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aranya.Web.ViewModel
{
    public class VMVillaNumber
    {
        public VillaNumber? villaNumber { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? villaList { get; set; }
    }
}

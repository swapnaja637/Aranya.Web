using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aranya.Domain.Entities
{
    public class Villa
    {
        public int Id { get; set; }
        [Display(Name = "Villa Name")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int Occupancy { get; set; }
        public double Rate { get; set; }
        public string Area { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }


    }
}

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
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name="Upload Image")]
        public string ImageUrl { get; set; }
        [Display(Name="Is Occupied")]
        [Range(1,5)]
        public int Occupancy { get; set; }
        [Display (Name = " Rate Per Night")]
        [Range(150,1000)]
        public double Rate { get; set; }
        [Display (Name="Villa Area")]
        public string Area { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public string? IsActive { get; set; } = "Y";


    }
}

using Aranya.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aranya.Infrastructure.Data
{
    public class ApplicationDBContext : DbContext

    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Villa> Tbl_Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id = 1,
                    Name = "Royal Villa For Family",
                    Description = "This is the description of the Royal Villa",
                    ImageUrl = "",
                    Occupancy = 4,
                    Rate = 200.0,
                    Area = "5000 sq ft",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                 new Villa
                 {
                     Id = 2,
                     Name = "Honeymoon sweet For Couple",
                     Description = "A special room for a special memories.",
                     ImageUrl = "",
                     Occupancy = 4,
                     Rate = 200.0,
                     Area = "5000 sq ft",
                     CreatedDate = DateTime.Now,
                     UpdatedDate = DateTime.Now
                 },
                  new Villa
                  {
                      Id = 3,
                      Name = "Delux villa for couple",
                      Description = "This is the delux ville with AC.",
                      ImageUrl = "",
                      Occupancy = 4,
                      Rate = 200.0,
                      Area = "5000 sq ft",
                      CreatedDate = DateTime.Now,
                      UpdatedDate = DateTime.Now
                  },
                   new Villa
                   {
                       Id = 4,
                       Name = "Sea facing villa",
                       Description = "This is the description of the Sea facing Villa",
                       ImageUrl = "",
                       Occupancy = 4,
                       Rate = 200.0,
                       Area = "5000 sq ft",
                       CreatedDate = DateTime.Now,
                       UpdatedDate = DateTime.Now
                   },
                   new Villa
                   {
                       Id = 5,
                       Name = "Tree Villa",
                       Description = "This is the description of the Tree Villa with AC and 2 rooms.",
                       ImageUrl = "",
                       Occupancy = 4,
                       Rate = 200.0,
                       Area = "5000 sq ft",
                       CreatedDate = DateTime.Now,
                       UpdatedDate = DateTime.Now
                   });
        }
    }
}

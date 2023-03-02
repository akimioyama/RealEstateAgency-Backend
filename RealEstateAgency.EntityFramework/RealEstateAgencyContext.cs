using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateAgency.Domain;

namespace RealEstateAgency.EntityFramework
{
    public class RealEstateAgencyContext : DbContext
    {
        public DbSet<Aparts> Aparts { get; set; }
        public DbSet<Arendatels> Arendatels { get; set; }
        
        public RealEstateAgencyContext()
        {
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-FPR118VN\SQLEXPRESS;Database=VKR;Trusted_Connection=True;");
        }
    }
}

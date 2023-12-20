using Microsoft.EntityFrameworkCore;
using PhoneDisplayer.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDisplayer.DataLayer
{
    public class PhoneContex : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Phone> Phones { get; set; }

        public PhoneContex()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=PhoneDb;Trusted_Connection=True;TrustServerCertificate=true;");
        }
    }
}

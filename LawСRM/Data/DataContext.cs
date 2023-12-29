using LawСRM.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawСRM.Data
{
    public class DataContext:DbContext
    {
       public DbSet<Admin> Admins { get; set; }
       public DbSet<AdminProfile> AdminProfiles { get; set; }
       public DbSet<Client> Clients { get; set; }
       public DbSet<IndividualClientProfile> IndividualClients { get; set; }
       public DbSet<LegalClientProfile> LegalClients { get; set; }
       public DbSet<LegalOrganizationForms> LegalOrganizationForms { get; set; }

        public DataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LawCRMDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}

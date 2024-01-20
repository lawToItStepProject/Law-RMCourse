using LawСRM.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace LawСRM.Data
{
    public class LawCRMDb:DbContext
    {
       public DbSet<Admin> Admins { get; set; }
       public DbSet<AdminProfile> AdminProfiles { get; set; }
       public DbSet<Client> Clients { get; set; }
       public DbSet<IndividualClientProfile> IndividualClients { get; set; }
       public DbSet<LegalClientProfile> LegalClients { get; set; }
       public DbSet<LegalOrganizationForms> LegalOrganizationForms { get; set; }

        public LawCRMDb(DbContextOptions<LawCRMDb> options) : base(options) { }
        //public lawCRMContext()
        //{
        //    Database.EnsureCreated();
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LawCRMDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //}
    }
}

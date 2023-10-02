using _008_EF_.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace _008_EF_
{
    internal class Context:DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }


        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = ".",
                InitialCatalog = "LinqToEntity",
                IntegratedSecurity = true,
                TrustServerCertificate = true,
            };
            optionsBuilder.UseSqlServer(builder.ConnectionString);

        }       
    }
}

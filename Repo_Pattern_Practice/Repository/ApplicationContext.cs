using Microsoft.EntityFrameworkCore;
using Repo_Pattern_Practice.DatabaseEntities;
using System.Configuration;
using System.Linq;

namespace Repo_Pattern_Practice.Repository
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Zipcode> Zipcodes { get; set; }

        public DbSet<Address> Addresses { get; set; }

        private string _connectionString = "Data Source=DESKTOP-0R2P5IM; Initial Catalog=Contacts; Integrated Security=True";

        public ApplicationContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}

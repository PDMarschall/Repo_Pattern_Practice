using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repo_Pattern_Practice.DatabaseEntities;

namespace Repo_Pattern_Practice.Repository
{
    class ApplicationContext : DbContext
    {
        public DbSet<Zipcode> Zipcodes { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public class ApplicationDbContext : DbContext
        {
            private readonly string _connectionString;

            public ApplicationDbContext(string connectionString)
            {
                _connectionString = connectionString;
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
    }
}

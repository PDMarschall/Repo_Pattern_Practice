﻿using Microsoft.EntityFrameworkCore;
using Repo_Pattern_Practice.DatabaseEntities;
using System.Configuration;
using System.Linq;

namespace Repo_Pattern_Practice.Repository
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Zipcode> Zipcodes { get; set; }

        public DbSet<Address> Addresses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["post"].ConnectionString);            
        }
    }
}

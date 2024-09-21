using Azure;
using dotnet_ef_exam.Configs;
using dotnet_ef_exam.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_ef_exam.EntityFramework
{
    internal class ExamDbContext : DbContext
    {
        private string connectionString = File.ReadAllText("connectionstring.txt");
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Community> Communities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
            new CountryEntityTypeConfiguration().Configure(modelBuilder.Entity<Country>());
            new CommunityEntityTypeConfiguration().Configure(modelBuilder.Entity<Community>());

            base.OnModelCreating(modelBuilder);
        }
    }
}

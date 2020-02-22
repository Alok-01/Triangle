using CS.Entities.InitialData;
using CS.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Entities
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            modelBuilder.ApplyConfiguration(new CompanyInitialData()); 
            modelBuilder.ApplyConfiguration(new EmployeeInitialData()); 
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}

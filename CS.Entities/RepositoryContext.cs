using CS.Entities.InitialData;
using CS.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Entities
{
    public class RepositoryContext: IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CompanyInitialData()); 
            modelBuilder.ApplyConfiguration(new EmployeeInitialData());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Travel2.Models;

namespace Travel2.Controllers
{
    public class AgencyDbContext : DbContext
    {
        public DbContextOptions<AgencyDbContext> Options { get; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Agent> Agents { get; set; }

        public AgencyDbContext() { }

        public AgencyDbContext(DbContextOptions<AgencyDbContext> options) : base(options)
        {
            Options = options;

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agency>().ToTable("Agencies");
            modelBuilder.Entity<Agent>().ToTable("Agents");
            modelBuilder.Entity<Agency>().Property(b => b.Id).ValueGeneratedOnAdd();
        }
    }
}

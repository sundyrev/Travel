using System.Linq;
using Travel2.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Validation;

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
            Database.EnsureCreated();

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agency>().ToTable("Agencies");
            modelBuilder.Entity<Agent>().ToTable("Agents");
            modelBuilder.Entity<Agency>().Property(b => b.Id).ValueGeneratedOnAdd();
        }
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errorMessages);
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }
}

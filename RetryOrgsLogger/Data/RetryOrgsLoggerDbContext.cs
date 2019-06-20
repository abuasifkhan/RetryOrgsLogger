using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RetryOrgsLogger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace RetryOrgsLogger.Data
{
    public class RetryOrgsLoggerDbContext: DbContext
    {
        public RetryOrgsLoggerDbContext(DbContextOptions<RetryOrgsLoggerDbContext> options) : base(options)
        {

        }
        public DbSet<RetryOrg> RetryOrgs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RetryOrg>()
                .HasKey(c => new { c.Geo, c.organizationId });
        }
    }
    public class RetryOrgsLoggerDbFactory : IDesignTimeDbContextFactory<RetryOrgsLoggerDbContext>
    {
        RetryOrgsLoggerDbContext IDesignTimeDbContextFactory<RetryOrgsLoggerDbContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RetryOrgsLoggerDbContext>();
            optionsBuilder.UseSqlServer<RetryOrgsLoggerDbContext>("Server=(localdb)\\MSSQLLocalDB;Database=RetryOrgsLogger;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new RetryOrgsLoggerDbContext(optionsBuilder.Options);
        }
    }
}

using DataApiDAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DataApiDAL
{
    public class JobContext : DbContext
    {
        public JobContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<JobVacancy> JobVacancies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<JobVacancy>().HasKey(i => i.Id);
            modelBuilder.Entity<JobVacancy>().Property(a => a.CompanyName).IsConcurrencyToken();
            base.OnModelCreating(modelBuilder);
        }
    }
}

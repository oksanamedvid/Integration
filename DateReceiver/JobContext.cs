using DateReceiver;
using Microsoft.EntityFrameworkCore;

namespace DataReceiver
{
    public class JobContext : DbContext
    {
        public DbSet<JobVacancy> JobVacancies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobVacancy>().HasKey(i => i.Id);
            modelBuilder.Entity<JobVacancy>().Property(a => a.CompanyName).IsConcurrencyToken();
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;userid=root;password=lv40-!R5;database=jobs");
        }
    }
}

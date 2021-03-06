using Microsoft.EntityFrameworkCore;
using SmsManager.Data.Configurations;
using SmsManager.Data.Entities;

namespace SmsManager.Data
{
    public class SmsManagerContext : DbContext
    {
        public DbSet<SmsMessageEntity> SmsMessages { get; set; }
        public DbSet<CountryEntity> Countries { get; set; }


        public SmsManagerContext(DbContextOptions<SmsManagerContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new SmsMessageConfiguration(modelBuilder.Entity<SmsMessageEntity>());
            new CountryConfiguration(modelBuilder.Entity<CountryEntity>());
        }
    }
}
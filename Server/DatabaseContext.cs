using EcoMonitor.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EcoMonitor.Server
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=null;database=ecomon;",
                new MySqlServerVersion(new Version(8, 0, 11))
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Record>().HasOne(r => r.Pollutant).WithMany().HasForeignKey(r => r.PollutantId);
            modelBuilder.Entity<Record>().HasOne(r => r.Object).WithMany().HasForeignKey(r => r.ObjectId);
        }

        public DbSet<Record> Records { get; set; }
        public DbSet<EcoMonitor.Shared.Object> Object { get; set; }
        public DbSet<Pollutant> Pollutant { get; set; }
    }
}

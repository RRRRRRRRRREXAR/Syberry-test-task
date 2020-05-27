using Microsoft.EntityFrameworkCore;
using SyberyCIStestask.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace SyberyCIStestask.DAL.Context
{
    class SyberryContext:DbContext
    {
        public DbSet<Emploee> Emploees { get; set; }
        public DbSet<TimeReport> TimeReports { get; set; }
        public SyberryContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimeReport>()
                .HasOne(t => t.Emploee)
                .WithMany();

            modelBuilder.Entity<Emploee>().HasData(
                new Emploee {Name = "John",Id = 1 },
                new Emploee {Name = "Jane",Id = 2 },
                new Emploee { Name = "Jax", Id = 3 }
                );
            modelBuilder.Entity<TimeReport>().HasData(
                new TimeReport { Id = 1, Date = DateTime.Now.AddDays(2), Hours = 7.5F, EmploeeId = 1 },
                new TimeReport { Id = 2, Date = DateTime.Now.AddDays(2), Hours = 4.5F, EmploeeId = 2 },
                new TimeReport { Id = 3, Date = DateTime.Now.AddDays(2), Hours = 5.5F, EmploeeId = 3 },
                new TimeReport { Id = 4, Date = DateTime.Now.AddDays(3), Hours = 5.5F, EmploeeId = 1 },
                new TimeReport { Id = 5, Date = DateTime.Now.AddDays(3), Hours = 6.5F, EmploeeId = 2 },
                new TimeReport { Id = 6, Date = DateTime.Now.AddDays(4), Hours = 8.5F, EmploeeId = 1 },
                new TimeReport { Id = 7, Date = DateTime.Now.AddDays(4), Hours = 1.5F, EmploeeId = 2 },
                new TimeReport { Id = 8, Date = DateTime.Now.AddDays(5), Hours = 3.2F, EmploeeId = 1 },
                new TimeReport { Id = 9, Date = DateTime.Now.AddDays(5), Hours = 4.5F, EmploeeId = 2 },
                new TimeReport { Id = 10, Date = DateTime.Now.AddDays(5), Hours = 6.5F, EmploeeId = 3 },
                new TimeReport { Id = 11, Date = DateTime.Now.AddDays(6), Hours = 5.4F, EmploeeId = 1 },
                new TimeReport { Id = 12, Date = DateTime.Now.AddDays(6), Hours = 6.3F, EmploeeId = 2 }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}

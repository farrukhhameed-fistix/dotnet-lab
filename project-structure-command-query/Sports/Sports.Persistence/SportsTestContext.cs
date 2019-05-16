using Microsoft.EntityFrameworkCore;
using Sports.Persistence;
using Sports.Domain.TestAggregate;
using Sports.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sports.Persistence
{
    public class SportsTestContext : DbContext, IUnitOfWork
    {
        public SportsTestContext(DbContextOptions<SportsTestContext> options)
            :base(options)
        {

        }

        public DbSet<Test> Tests { get; set; }
        public DbSet<AthleteTest> AthleteTests { get; set; }
        public DbSet<Athlete> Athletes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>().ToTable("Tests");
            modelBuilder.Entity<Test>().HasMany(r => r.Athletes).WithOne().HasForeignKey(k => k.TestId);

            modelBuilder.Entity<AthleteTest>().ToTable("AthleteTests");
            modelBuilder.Entity<AthleteTest>().HasOne(r => r.Athlete).WithOne().HasPrincipalKey<AthleteTest>(f => f.AthleteId);
        }
    }
}

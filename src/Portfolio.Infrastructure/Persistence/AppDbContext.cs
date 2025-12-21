using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>().HasKey(x => x.Id);
            modelBuilder.Entity<Skill>().Property(x => x.Type).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Skill>().Property(x => x.Details).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Skill>().Property(x => x.FontAwesomeHTML).HasMaxLength(100).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}

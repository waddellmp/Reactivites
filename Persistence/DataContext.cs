using System;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Activity> Activities { get; set; }

        public DbSet<Value> Values { get; set; }
        
        // Seed data in database by EF hook
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Configure Value Entity as migration is being created
            builder.Entity<Value>().HasData(
                new Value {Id = 1, Name= "Value 101"},
                new Value {Id = 2, Name= "Value 102"},
                new Value {Id = 3, Name= "Value 103"}
            );
        }
    }
}

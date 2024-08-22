using Microsoft.EntityFrameworkCore;
using System;
using LearnMath.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;

namespace LearnMath.Infrastructure.DataAccess
{
    public class LearnMathContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("LearnMathDb");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Teacher>(teacher =>
            {
                var id = teacher.Property(e => e.Id).ValueGeneratedOnAdd();
                if (Database.IsInMemory())
                {
                    //id.HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
                }
            });
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addreses { get; set; }
    }
}

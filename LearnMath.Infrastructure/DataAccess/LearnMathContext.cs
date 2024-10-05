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
            modelBuilder.Entity<User>(user =>
            {
                var id = user.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<UserOpinion>(opinion =>
            {
                var id = opinion.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserOpinion> Opinions { get; set; }
        public DbSet<Address> Addreses { get; set; }
    }
}

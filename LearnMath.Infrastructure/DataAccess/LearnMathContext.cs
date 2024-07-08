using Microsoft.EntityFrameworkCore;
using System;
using LearnMath.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Infrastructure.DataAccess
{
    public class LearnMathContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("LearnMathDb");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addreses { get; set; }
    }
}

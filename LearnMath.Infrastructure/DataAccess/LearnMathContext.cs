﻿using Microsoft.EntityFrameworkCore;
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
            optionsBuilder.UseSqlite(
            @"Data Source=C:\Users\Piotr\Desktop\NauczSięMatematyki\Database\LearnMath.db;");

            //optionsBuilder.UseInMemoryDatabase("LearnMathDb");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(user =>
            {
                var id = user.Property(e => e.Id).ValueGeneratedOnAdd();

                user.HasMany(u => u.UserSubjects)
                    .WithOne(s => s.Teacher)
                    .HasForeignKey(s => s.TeacherId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Konfiguracja relacji User (nauczyciel) -> Opinie
                user.HasMany(u => u.Opinions)
                    .WithOne(o => o.Teacher)
                    .HasForeignKey(o => o.TeacherId)
                    .OnDelete(DeleteBehavior.Cascade); // Usunięcie nauczyciela usuwa opinie
            });

            modelBuilder.Entity<UserSubject>(userSubject =>
            {
                var id = userSubject.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<UserOpinion>(opinion =>
            {
                var id = opinion.Property(e => e.Id).ValueGeneratedOnAdd();

                //// Konfiguracja relacji Opinia -> Student (CreatedByUser)
                //opinion.HasOne(o => o.CreatedByUser)
                //    .WithMany() // Student nie ma kolekcji opinii
                //    .HasForeignKey(o => o.CreatedByUserId)
                //    .OnDelete(DeleteBehavior.Restrict); // Usunięcie studenta nie usuwa opinii
            });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserOpinion> Opinions { get; set; }
        public DbSet<Address> Addreses { get; set; }
    }
}

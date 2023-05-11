using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HallOfFame.Models
{
    public class CompetenciesContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public CompetenciesContext(DbContextOptions<CompetenciesContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Skill>()
                .HasKey("PersonId","Name"); // Составной ключ

            ////Наполнение данными сотрудников
            modelBuilder.Entity<Person>()
                .HasData(
                new Person { Id = 1, Name = "Test1", DisplayName = "T1" },
                new Person { Id = 2, Name = "Test2", DisplayName = "T2" },
                new Person { Id = 3, Name = "Test3", DisplayName = "T3" },
                new Person { Id = 4, Name = "Test4", DisplayName = "T4" },
                new Person { Id = 5, Name = "Test5", DisplayName = "T5" }
                );

            //Наполнение данными навыков
            modelBuilder.Entity<Skill>()
                .HasData(
                new { Name = "Skill1", PersonId = (long)1, Level = (byte)1 },
                new { Name = "Skill2", PersonId = (long)2, Level = (byte)2 },
                new { Name = "Skill3", PersonId = (long)3, Level = (byte)3 },
                new { Name = "Skill4", PersonId = (long)4, Level = (byte)4 },
                new { Name = "Skill5", PersonId = (long)5, Level = (byte)5 }
                );

        }
    }
}

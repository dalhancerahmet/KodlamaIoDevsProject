using Kodlama.Io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Persistance.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgramingLanguage> ProgramingLanguages { get; set; }
        public DbSet<ProgramingLanguageTechnology> ProgramingLanguageTechnologies { get; set; }


        public BaseDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProgramingLanguage>(a =>
            {
                a.ToTable("ProgramingLanguage").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(m => m.ProgramingLanguageTechnologies);
            });

            modelBuilder.Entity<ProgramingLanguageTechnology>(p =>
            {
                p.ToTable("ProgramingLanguageTechnologies").HasKey(k => k.Id);
                p.Property(t=>t.Id).HasColumnName("Id");
                p.Property(t => t.ProgramingLanguageId).HasColumnName("ProgramingLanguageId");
                p.Property(t => t.Name).HasColumnName("Name");
                p.HasOne(m => m.ProgramingLanguage);
            });



            ProgramingLanguage[] programingLanguagesSeeds = new ProgramingLanguage[] { new() { Id = 1, Name = "C#" } }; 
            modelBuilder.Entity<ProgramingLanguage>().HasData(programingLanguagesSeeds);

            ProgramingLanguageTechnology[] programingLanguagesTechnologySeeds = { new(1,1,"WPF"), new(2,1,"ASP.NET") };
            modelBuilder.Entity<ProgramingLanguageTechnology>().HasData(programingLanguagesTechnologySeeds);
        }
    }
}

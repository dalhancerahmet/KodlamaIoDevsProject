using Core.Security.Entities;
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
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }



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
                a.ToTable("ProgramingLanguages").HasKey(k => k.Id);
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

            modelBuilder.Entity<User>(a =>
            {
                a.ToTable("Users").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(c => c.FirstName).HasColumnName("FirstName");
                a.Property(c => c.LastName).HasColumnName("LastName");
                a.Property(c => c.Email).HasColumnName("Email");
                a.Property(c => c.PasswordSalt).HasColumnName("PasswordSalt");
                a.Property(c => c.PasswordHash).HasColumnName("PasswordHash");
                a.Property(c => c.Status).HasColumnName("Status");
                a.Property(c => c.AuthenticatorType).HasColumnName("AuthenticatorType");

                a.HasMany(c => c.UserOperationClaims);
                a.HasMany(c => c.RefreshTokens);
            });

            modelBuilder.Entity<UserOperationClaim>(a =>
            {
                a.ToTable("UserOperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(c => c.UserId).HasColumnName("UserId");
                a.Property(c => c.OperationClaimId).HasColumnName("OperationClaimId");

                a.HasOne(c => c.OperationClaim);
                a.HasOne(c => c.User);
            });

            modelBuilder.Entity<OperationClaim>(u =>
            {
                u.ToTable("OperationClaims").HasKey(k => k.Id);
                u.Property(p => p.Id).HasColumnName("Id");
                u.Property(c => c.Name).HasColumnName("Name");
            });


            //ProgramingLanguage[] programingLanguagesSeeds = new ProgramingLanguage[] { new() { Id = 1, Name = "C#" } };
            //modelBuilder.Entity<ProgramingLanguage>().HasData(programingLanguagesSeeds);

            //ProgramingLanguageTechnology[] programingLanguagesTechnologySeeds = { new(1, 1, "WPF"), new(2, 1, "ASP.NET") };
            //modelBuilder.Entity<ProgramingLanguageTechnology>().HasData(programingLanguagesTechnologySeeds);
        }
    }
}

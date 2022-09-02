using Kodlama.Io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Persistance.Contexts
{
    public class BaseDbContext : DbContext
    {
        public DbSet<ProgramingLanguage> ProgramingLanguages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgramingLanguage>(p => {
                p.ToTable("ProgramingLanguage").HasKey(k=>k.Id);
                p.Property(pr=>pr.Id).HasColumnName("Id");
                p.Property(pr=>pr.Name).HasColumnName("Name");
            });
        }
    }
}

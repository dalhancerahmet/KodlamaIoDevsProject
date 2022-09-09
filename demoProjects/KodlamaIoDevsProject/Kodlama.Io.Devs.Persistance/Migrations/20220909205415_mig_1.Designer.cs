﻿// <auto-generated />
using Kodlama.Io.Devs.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kodlama.Io.Devs.Persistance.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20220909205415_mig_1")]
    partial class mig_1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Kodlama.Io.Devs.Domain.Entities.ProgramingLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("ProgramingLanguage", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "C#"
                        });
                });

            modelBuilder.Entity("Kodlama.Io.Devs.Domain.Entities.ProgramingLanguageTechnology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<int>("ProgramingLanguageId")
                        .HasColumnType("int")
                        .HasColumnName("ProgramingLanguageId");

                    b.HasKey("Id");

                    b.HasIndex("ProgramingLanguageId");

                    b.ToTable("ProgramingLanguageTechnologies", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "WPF",
                            ProgramingLanguageId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "ASP.NET",
                            ProgramingLanguageId = 1
                        });
                });

            modelBuilder.Entity("Kodlama.Io.Devs.Domain.Entities.ProgramingLanguageTechnology", b =>
                {
                    b.HasOne("Kodlama.Io.Devs.Domain.Entities.ProgramingLanguage", "ProgramingLanguage")
                        .WithMany("ProgramingLanguageTechnologies")
                        .HasForeignKey("ProgramingLanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProgramingLanguage");
                });

            modelBuilder.Entity("Kodlama.Io.Devs.Domain.Entities.ProgramingLanguage", b =>
                {
                    b.Navigation("ProgramingLanguageTechnologies");
                });
#pragma warning restore 612, 618
        }
    }
}

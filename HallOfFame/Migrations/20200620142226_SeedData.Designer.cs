﻿// <auto-generated />
using System;
using HallOfFame.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HallOfFame.Migrations
{
    [DbContext(typeof(CompetenciesContext))]
    [Migration("20200620142226_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HallOfFame.Models.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DisplayName = "T1",
                            Name = "Test1"
                        },
                        new
                        {
                            Id = 2L,
                            DisplayName = "T2",
                            Name = "Test2"
                        },
                        new
                        {
                            Id = 3L,
                            DisplayName = "T3",
                            Name = "Test3"
                        },
                        new
                        {
                            Id = 4L,
                            DisplayName = "T4",
                            Name = "Test4"
                        },
                        new
                        {
                            Id = 5L,
                            DisplayName = "T5",
                            Name = "Test5"
                        });
                });

            modelBuilder.Entity("HallOfFame.Models.Skill", b =>
                {
                    b.Property<long?>("PersonId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte>("Level")
                        .HasColumnType("tinyint");

                    b.HasKey("PersonId", "Name");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            PersonId = 1L,
                            Name = "Skill1",
                            Level = (byte)1
                        },
                        new
                        {
                            PersonId = 2L,
                            Name = "Skill2",
                            Level = (byte)2
                        },
                        new
                        {
                            PersonId = 3L,
                            Name = "Skill3",
                            Level = (byte)3
                        },
                        new
                        {
                            PersonId = 4L,
                            Name = "Skill4",
                            Level = (byte)4
                        },
                        new
                        {
                            PersonId = 5L,
                            Name = "Skill5",
                            Level = (byte)5
                        });
                });

            modelBuilder.Entity("HallOfFame.Models.Skill", b =>
                {
                    b.HasOne("HallOfFame.Models.Person", null)
                        .WithMany("Skills")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

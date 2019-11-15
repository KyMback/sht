﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SHT.Database.EF.Migrations;

namespace SHT.Database.EF.Migrations.Migrations
{
    [DbContext(typeof(MigrationDbContext))]
    partial class MigrationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SHT.Domain.Models.Tests.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<Guid>("TestVariantId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("character varying(4000)")
                        .HasMaxLength(4000);

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TestVariantId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("SHT.Domain.Models.Tests.Students.StudentQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("character varying(4000)")
                        .HasMaxLength(4000);

                    b.Property<double>("Grade")
                        .HasColumnType("double precision");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<Guid>("StudentTestVariantId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("character varying(4000)")
                        .HasMaxLength(4000);

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StudentTestVariantId");

                    b.ToTable("StudentQuestion");
                });

            modelBuilder.Entity("SHT.Domain.Models.Tests.Students.StudentTestSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TestSessionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TestSessionId");

                    b.ToTable("StudentTestSession");
                });

            modelBuilder.Entity("SHT.Domain.Models.Tests.Students.StudentTestVariant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TestSessionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TestSessionId");

                    b.ToTable("StudentTestVariant");
                });

            modelBuilder.Entity("SHT.Domain.Models.Tests.Students.TestSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("InstructorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("InstructorId");

                    b.ToTable("TestSession");
                });

            modelBuilder.Entity("SHT.Domain.Models.Tests.Students.TestSessionTestVariant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("TestSessionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TestVariantId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TestSessionId");

                    b.HasIndex("TestVariantId");

                    b.ToTable("TestSessionTestVariant");
                });

            modelBuilder.Entity("SHT.Domain.Models.Tests.TestVariant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("TestVariant");
                });

            modelBuilder.Entity("SHT.Domain.Models.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<int>("UserType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("SHT.Domain.Models.Tests.Question", b =>
                {
                    b.HasOne("SHT.Domain.Models.Tests.TestVariant", null)
                        .WithMany()
                        .HasForeignKey("TestVariantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.Tests.Students.StudentQuestion", b =>
                {
                    b.HasOne("SHT.Domain.Models.Tests.Students.StudentTestVariant", null)
                        .WithMany()
                        .HasForeignKey("StudentTestVariantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.Tests.Students.StudentTestSession", b =>
                {
                    b.HasOne("SHT.Domain.Models.Users.User", null)
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SHT.Domain.Models.Tests.Students.TestSession", null)
                        .WithMany("StudentTestSessions")
                        .HasForeignKey("TestSessionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.Tests.Students.StudentTestVariant", b =>
                {
                    b.HasOne("SHT.Domain.Models.Users.User", null)
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SHT.Domain.Models.Tests.Students.TestSession", null)
                        .WithMany()
                        .HasForeignKey("TestSessionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.Tests.Students.TestSession", b =>
                {
                    b.HasOne("SHT.Domain.Models.Users.User", null)
                        .WithMany()
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.Tests.Students.TestSessionTestVariant", b =>
                {
                    b.HasOne("SHT.Domain.Models.Tests.Students.TestSession", null)
                        .WithMany("TestSessionTestVariants")
                        .HasForeignKey("TestSessionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SHT.Domain.Models.Tests.TestVariant", null)
                        .WithMany()
                        .HasForeignKey("TestVariantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

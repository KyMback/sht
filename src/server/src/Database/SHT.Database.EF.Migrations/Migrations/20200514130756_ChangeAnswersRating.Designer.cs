﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SHT.Database.EF.Migrations;

namespace SHT.Database.EF.Migrations.Migrations
{
    [DbContext(typeof(MigrationDbContext))]
    [Migration("20200514130756_ChangeAnswersRating")]
    partial class ChangeAnswersRating
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "5.0.0-preview.3.20181.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.DataProtectionKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FriendlyName")
                        .HasColumnType("text");

                    b.Property<string>("Xml")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DataProtectionKeys","sht");
                });

            modelBuilder.Entity("SHT.Domain.Models.Questions.FreeTextQuestionTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("character varying(4000)")
                        .HasMaxLength(4000);

                    b.Property<Guid>("QuestionTemplateId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("QuestionTemplateId")
                        .IsUnique();

                    b.ToTable("FreeTextQuestionTemplate","sht");
                });

            modelBuilder.Entity("SHT.Domain.Models.Questions.QuestionTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("QuestionTemplate","sht");
                });

            modelBuilder.Entity("SHT.Domain.Models.Questions.WithChoice.ChoiceQuestionTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("QuestionTemplateId")
                        .HasColumnType("uuid");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("character varying(4000)")
                        .HasMaxLength(4000);

                    b.HasKey("Id");

                    b.HasIndex("QuestionTemplateId")
                        .IsUnique();

                    b.ToTable("ChoiceQuestionTemplate","sht");
                });

            modelBuilder.Entity("SHT.Domain.Models.Questions.WithChoice.ChoiceQuestionTemplateOption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ChoiceQuestionTemplateId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("boolean");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("character varying(4000)")
                        .HasMaxLength(4000);

                    b.HasKey("Id");

                    b.HasIndex("ChoiceQuestionTemplateId");

                    b.ToTable("ChoiceQuestionTemplateOption","sht");
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Assessments.AnswersAssessmentQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AssessmentId")
                        .HasColumnType("uuid");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("character varying(4000)")
                        .HasMaxLength(4000);

                    b.HasKey("Id");

                    b.HasIndex("AssessmentId");

                    b.ToTable("AnswersAssessmentQuestion","sht");
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Assessments.AnswersAssessmentQuestionTestSessionVariantQuestion", b =>
                {
                    b.Property<Guid>("AnswersAssessmentQuestionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TestSessionVariantQuestionId")
                        .HasColumnType("uuid");

                    b.HasKey("AnswersAssessmentQuestionId", "TestSessionVariantQuestionId");

                    b.HasIndex("TestSessionVariantQuestionId");

                    b.ToTable("AnswersAssessmentQuestion_TestSessionVariantQuestion","sht");
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Assessments.AnswersRating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AnswersAssessmentQuestionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AnswersAssessmentQuestionId");

                    b.HasIndex("StudentId");

                    b.ToTable("AnswersRating","sht");
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Assessments.AnswersRatingItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AnswersRatingId")
                        .HasColumnType("uuid");

                    b.Property<int?>("Rating")
                        .HasColumnType("integer");

                    b.Property<Guid>("StudentQuestionAnswerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StudentQuestionAnswerId");

                    b.HasIndex("AnswersRatingId", "StudentQuestionAnswerId")
                        .IsUnique();

                    b.ToTable("AnswersRatingItem","sht");
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Assessments.Assessment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("TestSessionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TestSessionId")
                        .IsUnique();

                    b.ToTable("Assessment","sht");
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Assessments.QuestionAnswerAssessment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AssessmentId")
                        .HasColumnType("uuid");

                    b.Property<double?>("Correctness")
                        .HasColumnType("double precision");

                    b.Property<Guid>("StudentQuestionAnswerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AssessmentId");

                    b.HasIndex("StudentQuestionAnswerId")
                        .IsUnique();

                    b.ToTable("QuestionAnswerAssessment","sht");
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Students.Answers.StudentChoiceQuestionAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("OptionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentQuestionAnswerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StudentQuestionAnswerId");

                    b.HasIndex("OptionId", "StudentQuestionAnswerId")
                        .IsUnique();

                    b.ToTable("StudentChoiceQuestionAnswer","sht");
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Students.Answers.StudentFreeTextQuestionAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Answer")
                        .HasColumnType("character varying(4000)")
                        .HasMaxLength(4000);

                    b.HasKey("Id");

                    b.ToTable("StudentFreeTextQuestionAnswer","sht");
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Students.Answers.StudentQuestionAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsAnswered")
                        .HasColumnType("boolean");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId")
                        .IsUnique();

                    b.ToTable("StudentQuestionAnswer","sht");
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Students.StudentTestSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TestSessionId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TestVariantId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TestSessionId");

                    b.HasIndex("TestVariantId");

                    b.ToTable("StudentTestSession","sht");
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Students.StudentTestSessionQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentTestSessionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("StudentTestSessionId");

                    b.ToTable("StudentTestSessionQuestion","sht");
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.TestSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

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

                    b.ToTable("TestSession","sht");
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Variants.Questions.TestSessionVariantChoiceQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("character varying(4000)")
                        .HasMaxLength(4000);

                    b.HasKey("Id");

                    b.ToTable("TestSessionVariantChoiceQuestion","sht");
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Variants.Questions.TestSessionVariantChoiceQuestionOption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("boolean");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("character varying(4000)")
                        .HasMaxLength(4000);

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("TestSessionVariantChoiceQuestionOption","sht");
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Variants.Questions.TestSessionVariantFreeTextQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("character varying(4000)")
                        .HasMaxLength(4000);

                    b.HasKey("Id");

                    b.ToTable("TestSessionVariantFreeTextQuestion","sht");
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Variants.Questions.TestSessionVariantQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<int?>("Order")
                        .HasColumnType("integer");

                    b.Property<Guid?>("SourceQuestionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TestSessionVariantId")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SourceQuestionId");

                    b.HasIndex("TestSessionVariantId");

                    b.ToTable("TestSessionVariantQuestion","sht");
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Variants.TestSessionVariant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsRandomOrder")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<Guid>("TestSessionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TestSessionId");

                    b.HasIndex("Name", "TestSessionId")
                        .IsUnique();

                    b.ToTable("TestSessionVariant","sht");
                });

            modelBuilder.Entity("SHT.Domain.Models.Tests.TestVariant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("TestVariant","sht");
                });

            modelBuilder.Entity("SHT.Domain.Models.Tests.TestVariantQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

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

                    b.ToTable("TestVariantQuestion","sht");
                });

            modelBuilder.Entity("SHT.Domain.Models.Users.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<bool>("IsEmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("SecurityStamp")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<int>("UserType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Account","sht");
                });

            modelBuilder.Entity("SHT.Domain.Models.Users.Instructor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Instructor","sht");
                });

            modelBuilder.Entity("SHT.Domain.Models.Users.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Student","sht");
                });

            modelBuilder.Entity("SHT.Domain.Models.Questions.FreeTextQuestionTemplate", b =>
                {
                    b.HasOne("SHT.Domain.Models.Questions.QuestionTemplate", null)
                        .WithOne("FreeTextQuestionTemplate")
                        .HasForeignKey("SHT.Domain.Models.Questions.FreeTextQuestionTemplate", "QuestionTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.Questions.QuestionTemplate", b =>
                {
                    b.HasOne("SHT.Domain.Models.Users.Instructor", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.Questions.WithChoice.ChoiceQuestionTemplate", b =>
                {
                    b.HasOne("SHT.Domain.Models.Questions.QuestionTemplate", null)
                        .WithOne("ChoiceQuestionTemplate")
                        .HasForeignKey("SHT.Domain.Models.Questions.WithChoice.ChoiceQuestionTemplate", "QuestionTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.Questions.WithChoice.ChoiceQuestionTemplateOption", b =>
                {
                    b.HasOne("SHT.Domain.Models.Questions.WithChoice.ChoiceQuestionTemplate", null)
                        .WithMany("Options")
                        .HasForeignKey("ChoiceQuestionTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Assessments.AnswersAssessmentQuestion", b =>
                {
                    b.HasOne("SHT.Domain.Models.TestSessions.Assessments.Assessment", "Assessment")
                        .WithMany("AnswersAssessmentQuestions")
                        .HasForeignKey("AssessmentId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Assessments.AnswersAssessmentQuestionTestSessionVariantQuestion", b =>
                {
                    b.HasOne("SHT.Domain.Models.TestSessions.Assessments.AnswersAssessmentQuestion", null)
                        .WithMany("Questions")
                        .HasForeignKey("AnswersAssessmentQuestionId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("SHT.Domain.Models.TestSessions.Variants.Questions.TestSessionVariantQuestion", "TestSessionVariantQuestion")
                        .WithMany()
                        .HasForeignKey("TestSessionVariantQuestionId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Assessments.AnswersRating", b =>
                {
                    b.HasOne("SHT.Domain.Models.TestSessions.Assessments.AnswersAssessmentQuestion", "AnswersAssessmentQuestion")
                        .WithMany("AnswersRatings")
                        .HasForeignKey("AnswersAssessmentQuestionId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("SHT.Domain.Models.Users.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Assessments.AnswersRatingItem", b =>
                {
                    b.HasOne("SHT.Domain.Models.TestSessions.Assessments.AnswersRating", null)
                        .WithMany("AnswersRatingItems")
                        .HasForeignKey("AnswersRatingId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("SHT.Domain.Models.TestSessions.Students.Answers.StudentQuestionAnswer", null)
                        .WithMany()
                        .HasForeignKey("StudentQuestionAnswerId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Assessments.Assessment", b =>
                {
                    b.HasOne("SHT.Domain.Models.TestSessions.TestSession", "TestSession")
                        .WithOne("Assessment")
                        .HasForeignKey("SHT.Domain.Models.TestSessions.Assessments.Assessment", "TestSessionId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Assessments.QuestionAnswerAssessment", b =>
                {
                    b.HasOne("SHT.Domain.Models.TestSessions.Assessments.Assessment", null)
                        .WithMany("QuestionAnswerAssessments")
                        .HasForeignKey("AssessmentId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("SHT.Domain.Models.TestSessions.Students.Answers.StudentQuestionAnswer", null)
                        .WithOne("AnswerAssessment")
                        .HasForeignKey("SHT.Domain.Models.TestSessions.Assessments.QuestionAnswerAssessment", "StudentQuestionAnswerId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Students.Answers.StudentChoiceQuestionAnswer", b =>
                {
                    b.HasOne("SHT.Domain.Models.TestSessions.Variants.Questions.TestSessionVariantChoiceQuestionOption", null)
                        .WithMany()
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SHT.Domain.Models.TestSessions.Students.Answers.StudentQuestionAnswer", null)
                        .WithMany("ChoiceQuestionAnswers")
                        .HasForeignKey("StudentQuestionAnswerId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Students.Answers.StudentFreeTextQuestionAnswer", b =>
                {
                    b.HasOne("SHT.Domain.Models.TestSessions.Students.Answers.StudentQuestionAnswer", null)
                        .WithOne("FreeTextAnswer")
                        .HasForeignKey("SHT.Domain.Models.TestSessions.Students.Answers.StudentFreeTextQuestionAnswer", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Students.Answers.StudentQuestionAnswer", b =>
                {
                    b.HasOne("SHT.Domain.Models.TestSessions.Students.StudentTestSessionQuestion", "Question")
                        .WithOne("Answer")
                        .HasForeignKey("SHT.Domain.Models.TestSessions.Students.Answers.StudentQuestionAnswer", "QuestionId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Students.StudentTestSession", b =>
                {
                    b.HasOne("SHT.Domain.Models.Users.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SHT.Domain.Models.TestSessions.TestSession", "TestSession")
                        .WithMany("StudentTestSessions")
                        .HasForeignKey("TestSessionId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("SHT.Domain.Models.TestSessions.Variants.TestSessionVariant", "Variant")
                        .WithMany()
                        .HasForeignKey("TestVariantId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Students.StudentTestSessionQuestion", b =>
                {
                    b.HasOne("SHT.Domain.Models.TestSessions.Variants.Questions.TestSessionVariantQuestion", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("SHT.Domain.Models.TestSessions.Students.StudentTestSession", "StudentTestSession")
                        .WithMany("Questions")
                        .HasForeignKey("StudentTestSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.TestSession", b =>
                {
                    b.HasOne("SHT.Domain.Models.Users.Instructor", null)
                        .WithMany()
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Variants.Questions.TestSessionVariantChoiceQuestion", b =>
                {
                    b.HasOne("SHT.Domain.Models.TestSessions.Variants.Questions.TestSessionVariantQuestion", null)
                        .WithOne("ChoiceQuestion")
                        .HasForeignKey("SHT.Domain.Models.TestSessions.Variants.Questions.TestSessionVariantChoiceQuestion", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Variants.Questions.TestSessionVariantChoiceQuestionOption", b =>
                {
                    b.HasOne("SHT.Domain.Models.TestSessions.Variants.Questions.TestSessionVariantChoiceQuestion", null)
                        .WithMany("Options")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Variants.Questions.TestSessionVariantFreeTextQuestion", b =>
                {
                    b.HasOne("SHT.Domain.Models.TestSessions.Variants.Questions.TestSessionVariantQuestion", null)
                        .WithOne("FreeTextQuestion")
                        .HasForeignKey("SHT.Domain.Models.TestSessions.Variants.Questions.TestSessionVariantFreeTextQuestion", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Variants.Questions.TestSessionVariantQuestion", b =>
                {
                    b.HasOne("SHT.Domain.Models.Questions.QuestionTemplate", null)
                        .WithMany()
                        .HasForeignKey("SourceQuestionId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("SHT.Domain.Models.TestSessions.Variants.TestSessionVariant", "TestSessionVariant")
                        .WithMany("Questions")
                        .HasForeignKey("TestSessionVariantId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.TestSessions.Variants.TestSessionVariant", b =>
                {
                    b.HasOne("SHT.Domain.Models.TestSessions.TestSession", "TestSession")
                        .WithMany("Variants")
                        .HasForeignKey("TestSessionId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.Tests.TestVariant", b =>
                {
                    b.HasOne("SHT.Domain.Models.Users.Instructor", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.Tests.TestVariantQuestion", b =>
                {
                    b.HasOne("SHT.Domain.Models.Tests.TestVariant", "TestVariant")
                        .WithMany("Questions")
                        .HasForeignKey("TestVariantId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.Users.Instructor", b =>
                {
                    b.HasOne("SHT.Domain.Models.Users.Account", "Account")
                        .WithOne()
                        .HasForeignKey("SHT.Domain.Models.Users.Instructor", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SHT.Domain.Models.Users.Student", b =>
                {
                    b.HasOne("SHT.Domain.Models.Users.Account", "Account")
                        .WithOne()
                        .HasForeignKey("SHT.Domain.Models.Users.Student", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

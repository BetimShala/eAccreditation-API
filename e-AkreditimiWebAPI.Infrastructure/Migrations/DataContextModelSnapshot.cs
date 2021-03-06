﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eAkreditimiWebAPI.Infrastructure.Data;

namespace e_AkreditimiWebAPI.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("e_AkreditimiWebAPI.Infrastructure.Models.AcademicStaffCommitments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AcademicYear");

                    b.Property<DateTime?>("DeclarationDate");

                    b.Property<int>("FacultyId");

                    b.Property<string>("StaffId");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.HasIndex("StaffId");

                    b.ToTable("AcademicStaffCommitments");
                });

            modelBuilder.Entity("e_AkreditimiWebAPI.Infrastructure.Models.AccreditationApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AcademicYear");

                    b.Property<int>("AccreditationTypeId");

                    b.Property<DateTime?>("ApplicationDate");

                    b.Property<int>("MeetingId");

                    b.Property<int>("UniversityId");

                    b.Property<DateTime?>("ValidFromDate");

                    b.Property<DateTime?>("ValidToDate");

                    b.Property<DateTime?>("VerdictDate");

                    b.Property<int>("VerdictId");

                    b.HasKey("Id");

                    b.HasIndex("AccreditationTypeId");

                    b.HasIndex("UniversityId");

                    b.HasIndex("VerdictId");

                    b.ToTable("AccreditationApplications");
                });

            modelBuilder.Entity("e_AkreditimiWebAPI.Infrastructure.Models.AccreditationStudyProgrammes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccreditationApplicationId");

                    b.Property<DateTime>("ApplyDate");

                    b.Property<string>("DiplomaName");

                    b.Property<string>("ECTS");

                    b.Property<int>("EducationLevelId");

                    b.Property<string>("Esac");

                    b.Property<string>("EsacField");

                    b.Property<int>("FacultyId");

                    b.Property<int>("MaxNumber");

                    b.Property<string>("ProgrammDescription");

                    b.Property<string>("SpecialismDescription");

                    b.Property<int>("StudyDuration");

                    b.Property<string>("StudyType");

                    b.HasKey("Id");

                    b.HasIndex("AccreditationApplicationId");

                    b.HasIndex("EducationLevelId");

                    b.HasIndex("FacultyId");

                    b.ToTable("AccreditationStudyProgrammes");
                });

            modelBuilder.Entity("e_AkreditimiWebAPI.Infrastructure.Models.AccreditationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("AccreditationTypes");
                });

            modelBuilder.Entity("e_AkreditimiWebAPI.Infrastructure.Models.AccrStudyProgrammesSubjects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccrSPId");

                    b.Property<int>("ClinicNum");

                    b.Property<int>("ConsultationNum");

                    b.Property<int>("CreditsNum");

                    b.Property<string>("Description");

                    b.Property<int>("ExercisesNum");

                    b.Property<int>("LecturesNum");

                    b.Property<int>("PracticeNum");

                    b.Property<string>("ProfessorId");

                    b.Property<int>("ResearchNum");

                    b.Property<int>("SemesterId");

                    b.Property<string>("SubjectCode");

                    b.HasKey("Id");

                    b.HasIndex("AccrSPId");

                    b.HasIndex("ProfessorId");

                    b.HasIndex("SemesterId");

                    b.ToTable("AccrStudyProgrammesSubjects");
                });

            modelBuilder.Entity("e_AkreditimiWebAPI.Infrastructure.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int>("CountryId");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsMale");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("MaidenName");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PersonalNumber");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("e_AkreditimiWebAPI.Infrastructure.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("e_AkreditimiWebAPI.Infrastructure.Models.EducationLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("EducationLevels");
                });

            modelBuilder.Entity("e_AkreditimiWebAPI.Infrastructure.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("UniversityId");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("e_AkreditimiWebAPI.Infrastructure.Models.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("e_AkreditimiWebAPI.Infrastructure.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("e_AkreditimiWebAPI.Infrastructure.Models.Verdict", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Verdicts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("e_AkreditimiWebAPI.Infrastructure.Models.AcademicStaffCommitments", b =>
                {
                    b.HasOne("e_AkreditimiWebAPI.Infrastructure.Models.Faculty", "Faculty")
                        .WithMany("AcademicStaffCommitments")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("e_AkreditimiWebAPI.Infrastructure.Models.ApplicationUser", "Staff")
                        .WithMany("AcademicStaffCommitments")
                        .HasForeignKey("StaffId");
                });

            modelBuilder.Entity("e_AkreditimiWebAPI.Infrastructure.Models.AccreditationApplication", b =>
                {
                    b.HasOne("e_AkreditimiWebAPI.Infrastructure.Models.AccreditationType", "AccreditationType")
                        .WithMany("AccreditationApplications")
                        .HasForeignKey("AccreditationTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("e_AkreditimiWebAPI.Infrastructure.Models.University", "University")
                        .WithMany("AccreditationApplications")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("e_AkreditimiWebAPI.Infrastructure.Models.Verdict", "Verdict")
                        .WithMany("AccreditationApplications")
                        .HasForeignKey("VerdictId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("e_AkreditimiWebAPI.Infrastructure.Models.AccreditationStudyProgrammes", b =>
                {
                    b.HasOne("e_AkreditimiWebAPI.Infrastructure.Models.AccreditationApplication", "AccreditationApplication")
                        .WithMany("AccreditationStudyProgrammes")
                        .HasForeignKey("AccreditationApplicationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("e_AkreditimiWebAPI.Infrastructure.Models.EducationLevel", "EducationLevel")
                        .WithMany("AccreditationStudyProgrammes")
                        .HasForeignKey("EducationLevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("e_AkreditimiWebAPI.Infrastructure.Models.Faculty", "Faculty")
                        .WithMany("AccreditationStudyProgrammes")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("e_AkreditimiWebAPI.Infrastructure.Models.AccrStudyProgrammesSubjects", b =>
                {
                    b.HasOne("e_AkreditimiWebAPI.Infrastructure.Models.AccreditationStudyProgrammes", "AccrSP")
                        .WithMany("AccrStudyProgrammesSubjects")
                        .HasForeignKey("AccrSPId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("e_AkreditimiWebAPI.Infrastructure.Models.ApplicationUser", "Professor")
                        .WithMany("AccrStudyProgrammesSubjects")
                        .HasForeignKey("ProfessorId");

                    b.HasOne("e_AkreditimiWebAPI.Infrastructure.Models.Semester", "Semester")
                        .WithMany("AccrStudyProgrammesSubjects")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("e_AkreditimiWebAPI.Infrastructure.Models.ApplicationUser", b =>
                {
                    b.HasOne("e_AkreditimiWebAPI.Infrastructure.Models.Country", "Country")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("e_AkreditimiWebAPI.Infrastructure.Models.Faculty", b =>
                {
                    b.HasOne("e_AkreditimiWebAPI.Infrastructure.Models.University", "University")
                        .WithMany("Faculties")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("e_AkreditimiWebAPI.Infrastructure.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("e_AkreditimiWebAPI.Infrastructure.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("e_AkreditimiWebAPI.Infrastructure.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("e_AkreditimiWebAPI.Infrastructure.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

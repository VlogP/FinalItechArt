﻿// <auto-generated />
using System;
using FinalltechArt.DB.DBRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinalltechArt.DB.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20200602030438_DrugAtClinics")]
    partial class DrugAtClinics
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FinalltechArt.DB.Models.Clinic", b =>
                {
                    b.Property<string>("ClinicId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ClinicId");

                    b.ToTable("Clinics");
                });

            modelBuilder.Entity("FinalltechArt.DB.Models.DrugAtClinics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClinicId");

                    b.Property<int>("Count");

                    b.Property<int>("DrugUnitId");

                    b.Property<string>("DrugUnitName");

                    b.HasKey("Id");

                    b.ToTable("DrugAtClinics");
                });

            modelBuilder.Entity("FinalltechArt.DB.Models.DrugType", b =>
                {
                    b.Property<int>("DrugTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Value");

                    b.HasKey("DrugTypeId");

                    b.ToTable("DrugTypes");
                });

            modelBuilder.Entity("FinalltechArt.DB.Models.DrugUnit", b =>
                {
                    b.Property<int>("DrugUnitId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Capacity")
                        .IsRequired();

                    b.Property<string>("ClinicId");

                    b.Property<int>("Count");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("DrugType")
                        .IsRequired();

                    b.Property<string>("Manufacturer")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("TypeCapacity")
                        .IsRequired();

                    b.Property<int?>("VisitId");

                    b.HasKey("DrugUnitId");

                    b.HasIndex("VisitId")
                        .IsUnique()
                        .HasFilter("[VisitId] IS NOT NULL");

                    b.ToTable("DrugUnits");
                });

            modelBuilder.Entity("FinalltechArt.DB.Models.Gender", b =>
                {
                    b.Property<int>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Value");

                    b.HasKey("GenderId");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("FinalltechArt.DB.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BirthDate")
                        .IsRequired();

                    b.Property<string>("ClinicId")
                        .IsRequired();

                    b.Property<string>("DrugType");

                    b.Property<string>("Firstname")
                        .IsRequired();

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<string>("Lastname")
                        .IsRequired();

                    b.Property<string>("Status")
                        .IsRequired();

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("FinalltechArt.DB.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Value");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("FinalltechArt.DB.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Value");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("FinalltechArt.DB.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClinicId");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Firstname")
                        .IsRequired();

                    b.Property<string>("Initials")
                        .IsRequired();

                    b.Property<string>("Lastname")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("Role");

                    b.Property<string>("Sault");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FinalltechArt.DB.Models.Visit", b =>
                {
                    b.Property<int>("VisitId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PatientId");

                    b.Property<string>("VisitDate")
                        .IsRequired();

                    b.HasKey("VisitId");

                    b.HasIndex("PatientId");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("FinalltechArt.DB.Models.DrugUnit", b =>
                {
                    b.HasOne("FinalltechArt.DB.Models.Visit", "Visit")
                        .WithOne("DrugUnit")
                        .HasForeignKey("FinalltechArt.DB.Models.DrugUnit", "VisitId");
                });

            modelBuilder.Entity("FinalltechArt.DB.Models.Visit", b =>
                {
                    b.HasOne("FinalltechArt.DB.Models.Patient", "Patient")
                        .WithMany("Visits")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StaffTemplate.server.Data;

#nullable disable

namespace StaffTemplate.server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240709164403_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("StaffTemplate.server.Models.Address", b =>
                {
                    b.Property<int>("SocialSecurityNumber")
                        .HasColumnType("integer");

                    b.Property<string>("AddressLine")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("SocialSecurityNumber");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("StaffTemplate.server.Models.ContactInfo", b =>
                {
                    b.Property<int>("SocialSecurityNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.HasKey("SocialSecurityNumber");

                    b.ToTable("ContactInfos");
                });

            modelBuilder.Entity("StaffTemplate.server.Models.EmergencyContact", b =>
                {
                    b.Property<int>("SocialSecurityNumber")
                        .HasColumnType("integer");

                    b.Property<string>("EmergencyContactName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("EmergencyPhone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<string>("EmergencyRelationship")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("SocialSecurityNumber");

                    b.ToTable("EmergencyContacts");
                });

            modelBuilder.Entity("StaffTemplate.server.Models.Employee", b =>
                {
                    b.Property<int>("SocialSecurityNumber")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(11)
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SocialSecurityNumber"));

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("CURP")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("character varying(18)");

                    b.Property<int>("Children")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("MaritalStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("RFC")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.Property<string>("SecondLastname")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("StudyGrade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("SocialSecurityNumber");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("StaffTemplate.server.Models.EmploymentDetails", b =>
                {
                    b.Property<int>("SocialSecurityNumber")
                        .HasColumnType("integer");

                    b.Property<string>("BossName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("HiredBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("HiringDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsFileComplete")
                        .HasColumnType("boolean");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Shift")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("SocialSecurityNumber");

                    b.ToTable("EmploymentDetails");
                });

            modelBuilder.Entity("StaffTemplate.server.Models.Address", b =>
                {
                    b.HasOne("StaffTemplate.server.Models.Employee", "Employee")
                        .WithOne("Address")
                        .HasForeignKey("StaffTemplate.server.Models.Address", "SocialSecurityNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("StaffTemplate.server.Models.ContactInfo", b =>
                {
                    b.HasOne("StaffTemplate.server.Models.Employee", "Employee")
                        .WithOne("ContactInfo")
                        .HasForeignKey("StaffTemplate.server.Models.ContactInfo", "SocialSecurityNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("StaffTemplate.server.Models.EmergencyContact", b =>
                {
                    b.HasOne("StaffTemplate.server.Models.Employee", "Employee")
                        .WithOne("EmergencyContact")
                        .HasForeignKey("StaffTemplate.server.Models.EmergencyContact", "SocialSecurityNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("StaffTemplate.server.Models.EmploymentDetails", b =>
                {
                    b.HasOne("StaffTemplate.server.Models.Employee", "Employee")
                        .WithOne("EmploymentDetails")
                        .HasForeignKey("StaffTemplate.server.Models.EmploymentDetails", "SocialSecurityNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("StaffTemplate.server.Models.Employee", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("ContactInfo")
                        .IsRequired();

                    b.Navigation("EmergencyContact")
                        .IsRequired();

                    b.Navigation("EmploymentDetails")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

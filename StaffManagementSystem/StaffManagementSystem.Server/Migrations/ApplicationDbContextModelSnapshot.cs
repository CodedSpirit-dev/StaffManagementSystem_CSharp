﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using StaffTemplate.Server.Data;

#nullable disable

namespace StaffManagementSystem.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("StaffManagementSystem.Server.Models.Employee", b =>
                {
                    b.Property<int>("SocialSecurityNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SocialSecurityNumber"));

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("BloodType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

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
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("SocialSecurityNumber");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("StaffManagementSystem.Server.Models.Employee", b =>
                {
                    b.OwnsOne("StaffManagementSystem.Server.Models.Address", "Address", b1 =>
                        {
                            b1.Property<int>("EmployeeSocialSecurityNumber")
                                .HasColumnType("integer");

                            b1.Property<string>("AddressLine")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("character varying(200)");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.Property<string>("Neighborhood")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("character varying(10)");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.HasKey("EmployeeSocialSecurityNumber");

                            b1.ToTable("Employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeSocialSecurityNumber");
                        });

                    b.OwnsOne("StaffManagementSystem.Server.Models.ContactInfo", "ContactInfo", b1 =>
                        {
                            b1.Property<int>("EmployeeSocialSecurityNumber")
                                .HasColumnType("integer");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("character varying(15)");

                            b1.HasKey("EmployeeSocialSecurityNumber");

                            b1.ToTable("Employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeSocialSecurityNumber");
                        });

                    b.OwnsOne("StaffManagementSystem.Server.Models.EmergencyContact", "EmergencyContact", b1 =>
                        {
                            b1.Property<int>("EmployeeSocialSecurityNumber")
                                .HasColumnType("integer");

                            b1.Property<string>("EmergencyContactName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.Property<string>("EmergencyPhone")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("character varying(15)");

                            b1.Property<string>("EmergencyRelationship")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)");

                            b1.HasKey("EmployeeSocialSecurityNumber");

                            b1.ToTable("Employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeSocialSecurityNumber");
                        });

                    b.OwnsOne("StaffManagementSystem.Server.Models.EmploymentDetails", "EmploymentDetails", b1 =>
                        {
                            b1.Property<int>("EmployeeSocialSecurityNumber")
                                .HasColumnType("integer");

                            b1.Property<string>("BossName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.Property<string>("Department")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.Property<string>("HiredBy")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.Property<DateTime>("HiringDate")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<bool>("InsuranceActive")
                                .HasColumnType("boolean");

                            b1.Property<bool>("IsActive")
                                .HasColumnType("boolean");

                            b1.Property<bool>("IsFileComplete")
                                .HasColumnType("boolean");

                            b1.Property<string>("Notes")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("character varying(500)");

                            b1.Property<string>("Position")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.Property<DateTime?>("ResignationDate")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("Shift")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)");

                            b1.HasKey("EmployeeSocialSecurityNumber");

                            b1.ToTable("Employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeSocialSecurityNumber");
                        });

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

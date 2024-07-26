using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace StaffManagementSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    SocialSecurityNumber = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RFC = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    CURP = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SecondLastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    BloodType = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    MaritalStatus = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Children = table.Column<int>(type: "integer", nullable: false),
                    ContactInfo_Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ContactInfo_PhoneNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Address_Street = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Address_Number = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Address_PostalCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Address_Neighborhood = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Address_City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Address_State = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EmploymentDetails_Position = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EmploymentDetails_Department = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EmploymentDetails_DateOfJoining = table.Column<DateOnly>(type: "date", nullable: false),
                    EmploymentDetails_HiringDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EmploymentDetails_ResignationDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EmploymentDetails_BossName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EmploymentDetails_Shift = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    EmploymentDetails_HiredBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EmploymentDetails_StudyGrade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    EmploymentDetails_Salary = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    EmploymentDetails_BankName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    EmploymentDetails_InterbankClabe = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: true),
                    EmploymentDetails_PaymentFrequency = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    EmploymentDetails_PayrollType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    EmploymentDetails_IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    EmploymentDetails_InsuranceActive = table.Column<bool>(type: "boolean", nullable: false),
                    EmploymentDetails_IsFileComplete = table.Column<bool>(type: "boolean", nullable: false),
                    EmploymentDetails_BirthCertificate = table.Column<bool>(type: "boolean", nullable: false),
                    EmploymentDetails_NoCriminalRecordCertificate = table.Column<bool>(type: "boolean", nullable: false),
                    EmploymentDetails_INE = table.Column<bool>(type: "boolean", maxLength: 18, nullable: true),
                    EmploymentDetails_RegistrationDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EmploymentDetails_Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    EmergencyContact_EmergencyContactName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EmergencyContact_EmergencyPhone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    EmergencyContact_EmergencyRelationship = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.SocialSecurityNumber);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}

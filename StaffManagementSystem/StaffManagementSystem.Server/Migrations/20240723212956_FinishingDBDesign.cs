using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffManagementSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class FinishingDBDesign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Asegurado",
                table: "Employees",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BirthCertificate",
                table: "Employees",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EmploymentDetails_BankName",
                table: "Employees",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmploymentDetails_InterbankClabe",
                table: "Employees",
                type: "character varying(18)",
                maxLength: 18,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EmploymentDetails_MonthlySalary",
                table: "Employees",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "EmploymentDetails_PaymentFrequency",
                table: "Employees",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmploymentDetails_PayrollType",
                table: "Employees",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estatus",
                table: "Employees",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDeRegistro",
                table: "Employees",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "INE",
                table: "Employees",
                type: "character varying(18)",
                maxLength: 18,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NoCriminalRecordCertificate",
                table: "Employees",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Asegurado",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BirthCertificate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmploymentDetails_BankName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmploymentDetails_InterbankClabe",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmploymentDetails_MonthlySalary",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmploymentDetails_PaymentFrequency",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmploymentDetails_PayrollType",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Estatus",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FechaDeRegistro",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "INE",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NoCriminalRecordCertificate",
                table: "Employees");
        }
    }
}

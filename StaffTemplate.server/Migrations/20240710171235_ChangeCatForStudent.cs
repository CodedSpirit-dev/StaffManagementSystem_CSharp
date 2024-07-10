using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace StaffTemplate.server.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCatForStudent : Migration
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
                    MiddleName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SecondLastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    MaritalStatus = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Children = table.Column<int>(type: "integer", nullable: false),
                    StudyGrade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.SocialSecurityNumber);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    SocialSecurityNumber = table.Column<int>(type: "integer", nullable: false),
                    AddressLine = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    PostalCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Neighborhood = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.SocialSecurityNumber);
                    table.ForeignKey(
                        name: "FK_Addresses_Employees_SocialSecurityNumber",
                        column: x => x.SocialSecurityNumber,
                        principalTable: "Employees",
                        principalColumn: "SocialSecurityNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactInfos",
                columns: table => new
                {
                    SocialSecurityNumber = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfos", x => x.SocialSecurityNumber);
                    table.ForeignKey(
                        name: "FK_ContactInfos_Employees_SocialSecurityNumber",
                        column: x => x.SocialSecurityNumber,
                        principalTable: "Employees",
                        principalColumn: "SocialSecurityNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyContacts",
                columns: table => new
                {
                    EmergencyContactId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SocialSecurityNumber = table.Column<int>(type: "integer", nullable: false),
                    EmergencyContactName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EmergencyPhone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    EmergencyRelationship = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyContacts", x => x.EmergencyContactId);
                    table.ForeignKey(
                        name: "FK_EmergencyContacts_Employees_SocialSecurityNumber",
                        column: x => x.SocialSecurityNumber,
                        principalTable: "Employees",
                        principalColumn: "SocialSecurityNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentDetails",
                columns: table => new
                {
                    SocialSecurityNumber = table.Column<int>(type: "integer", nullable: false),
                    HiringDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Department = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Position = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BossName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Shift = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    HiredBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsFileComplete = table.Column<bool>(type: "boolean", nullable: false),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentDetails", x => x.SocialSecurityNumber);
                    table.ForeignKey(
                        name: "FK_EmploymentDetails_Employees_SocialSecurityNumber",
                        column: x => x.SocialSecurityNumber,
                        principalTable: "Employees",
                        principalColumn: "SocialSecurityNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContacts_SocialSecurityNumber",
                table: "EmergencyContacts",
                column: "SocialSecurityNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "ContactInfos");

            migrationBuilder.DropTable(
                name: "EmergencyContacts");

            migrationBuilder.DropTable(
                name: "EmploymentDetails");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}

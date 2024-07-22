using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffManagementSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class _6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_AddressLine",
                table: "Employees",
                newName: "Address_Street");

            migrationBuilder.AddColumn<string>(
                name: "Address_Number",
                table: "Employees",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_Number",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "Employees",
                newName: "Address_AddressLine");
        }
    }
}

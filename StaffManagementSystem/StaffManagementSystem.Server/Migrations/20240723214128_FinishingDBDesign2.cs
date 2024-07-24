using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffManagementSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class FinishingDBDesign2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Asegurado",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Estatus",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "EmploymentDetails_Shift",
                table: "Employees",
                newName: "employmentDetails_Shift");

            migrationBuilder.RenameColumn(
                name: "EmploymentDetails_ResignationDate",
                table: "Employees",
                newName: "employmentDetails_ResignationDate");

            migrationBuilder.RenameColumn(
                name: "EmploymentDetails_Position",
                table: "Employees",
                newName: "employmentDetails_Position");

            migrationBuilder.RenameColumn(
                name: "EmploymentDetails_PayrollType",
                table: "Employees",
                newName: "employmentDetails_PayrollType");

            migrationBuilder.RenameColumn(
                name: "EmploymentDetails_PaymentFrequency",
                table: "Employees",
                newName: "employmentDetails_PaymentFrequency");

            migrationBuilder.RenameColumn(
                name: "EmploymentDetails_Notes",
                table: "Employees",
                newName: "employmentDetails_Notes");

            migrationBuilder.RenameColumn(
                name: "EmploymentDetails_MonthlySalary",
                table: "Employees",
                newName: "employmentDetails_MonthlySalary");

            migrationBuilder.RenameColumn(
                name: "EmploymentDetails_IsFileComplete",
                table: "Employees",
                newName: "employmentDetails_IsFileComplete");

            migrationBuilder.RenameColumn(
                name: "EmploymentDetails_IsActive",
                table: "Employees",
                newName: "employmentDetails_IsActive");

            migrationBuilder.RenameColumn(
                name: "EmploymentDetails_InterbankClabe",
                table: "Employees",
                newName: "employmentDetails_InterbankClabe");

            migrationBuilder.RenameColumn(
                name: "EmploymentDetails_InsuranceActive",
                table: "Employees",
                newName: "employmentDetails_InsuranceActive");

            migrationBuilder.RenameColumn(
                name: "EmploymentDetails_HiringDate",
                table: "Employees",
                newName: "employmentDetails_HiringDate");

            migrationBuilder.RenameColumn(
                name: "EmploymentDetails_HiredBy",
                table: "Employees",
                newName: "employmentDetails_HiredBy");

            migrationBuilder.RenameColumn(
                name: "EmploymentDetails_Department",
                table: "Employees",
                newName: "employmentDetails_Department");

            migrationBuilder.RenameColumn(
                name: "EmploymentDetails_BossName",
                table: "Employees",
                newName: "employmentDetails_BossName");

            migrationBuilder.RenameColumn(
                name: "EmploymentDetails_BankName",
                table: "Employees",
                newName: "employmentDetails_BankName");

            migrationBuilder.RenameColumn(
                name: "EmergencyContact_EmergencyRelationship",
                table: "Employees",
                newName: "emergencyContact_EmergencyRelationship");

            migrationBuilder.RenameColumn(
                name: "EmergencyContact_EmergencyPhone",
                table: "Employees",
                newName: "emergencyContact_EmergencyPhone");

            migrationBuilder.RenameColumn(
                name: "EmergencyContact_EmergencyContactName",
                table: "Employees",
                newName: "emergencyContact_EmergencyContactName");

            migrationBuilder.RenameColumn(
                name: "ContactInfo_PhoneNumber",
                table: "Employees",
                newName: "contactInfo_PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "ContactInfo_Email",
                table: "Employees",
                newName: "contactInfo_Email");

            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "Employees",
                newName: "address_Street");

            migrationBuilder.RenameColumn(
                name: "Address_State",
                table: "Employees",
                newName: "address_State");

            migrationBuilder.RenameColumn(
                name: "Address_PostalCode",
                table: "Employees",
                newName: "address_PostalCode");

            migrationBuilder.RenameColumn(
                name: "Address_Number",
                table: "Employees",
                newName: "address_Number");

            migrationBuilder.RenameColumn(
                name: "Address_Neighborhood",
                table: "Employees",
                newName: "address_Neighborhood");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Employees",
                newName: "address_City");

            migrationBuilder.RenameColumn(
                name: "FechaDeRegistro",
                table: "Employees",
                newName: "employmentDetails_RegistrationDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "employmentDetails_Shift",
                table: "Employees",
                newName: "EmploymentDetails_Shift");

            migrationBuilder.RenameColumn(
                name: "employmentDetails_ResignationDate",
                table: "Employees",
                newName: "EmploymentDetails_ResignationDate");

            migrationBuilder.RenameColumn(
                name: "employmentDetails_Position",
                table: "Employees",
                newName: "EmploymentDetails_Position");

            migrationBuilder.RenameColumn(
                name: "employmentDetails_PayrollType",
                table: "Employees",
                newName: "EmploymentDetails_PayrollType");

            migrationBuilder.RenameColumn(
                name: "employmentDetails_PaymentFrequency",
                table: "Employees",
                newName: "EmploymentDetails_PaymentFrequency");

            migrationBuilder.RenameColumn(
                name: "employmentDetails_Notes",
                table: "Employees",
                newName: "EmploymentDetails_Notes");

            migrationBuilder.RenameColumn(
                name: "employmentDetails_MonthlySalary",
                table: "Employees",
                newName: "EmploymentDetails_MonthlySalary");

            migrationBuilder.RenameColumn(
                name: "employmentDetails_IsFileComplete",
                table: "Employees",
                newName: "EmploymentDetails_IsFileComplete");

            migrationBuilder.RenameColumn(
                name: "employmentDetails_IsActive",
                table: "Employees",
                newName: "EmploymentDetails_IsActive");

            migrationBuilder.RenameColumn(
                name: "employmentDetails_InterbankClabe",
                table: "Employees",
                newName: "EmploymentDetails_InterbankClabe");

            migrationBuilder.RenameColumn(
                name: "employmentDetails_InsuranceActive",
                table: "Employees",
                newName: "EmploymentDetails_InsuranceActive");

            migrationBuilder.RenameColumn(
                name: "employmentDetails_HiringDate",
                table: "Employees",
                newName: "EmploymentDetails_HiringDate");

            migrationBuilder.RenameColumn(
                name: "employmentDetails_HiredBy",
                table: "Employees",
                newName: "EmploymentDetails_HiredBy");

            migrationBuilder.RenameColumn(
                name: "employmentDetails_Department",
                table: "Employees",
                newName: "EmploymentDetails_Department");

            migrationBuilder.RenameColumn(
                name: "employmentDetails_BossName",
                table: "Employees",
                newName: "EmploymentDetails_BossName");

            migrationBuilder.RenameColumn(
                name: "employmentDetails_BankName",
                table: "Employees",
                newName: "EmploymentDetails_BankName");

            migrationBuilder.RenameColumn(
                name: "emergencyContact_EmergencyRelationship",
                table: "Employees",
                newName: "EmergencyContact_EmergencyRelationship");

            migrationBuilder.RenameColumn(
                name: "emergencyContact_EmergencyPhone",
                table: "Employees",
                newName: "EmergencyContact_EmergencyPhone");

            migrationBuilder.RenameColumn(
                name: "emergencyContact_EmergencyContactName",
                table: "Employees",
                newName: "EmergencyContact_EmergencyContactName");

            migrationBuilder.RenameColumn(
                name: "contactInfo_PhoneNumber",
                table: "Employees",
                newName: "ContactInfo_PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "contactInfo_Email",
                table: "Employees",
                newName: "ContactInfo_Email");

            migrationBuilder.RenameColumn(
                name: "address_Street",
                table: "Employees",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "address_State",
                table: "Employees",
                newName: "Address_State");

            migrationBuilder.RenameColumn(
                name: "address_PostalCode",
                table: "Employees",
                newName: "Address_PostalCode");

            migrationBuilder.RenameColumn(
                name: "address_Number",
                table: "Employees",
                newName: "Address_Number");

            migrationBuilder.RenameColumn(
                name: "address_Neighborhood",
                table: "Employees",
                newName: "Address_Neighborhood");

            migrationBuilder.RenameColumn(
                name: "address_City",
                table: "Employees",
                newName: "Address_City");

            migrationBuilder.RenameColumn(
                name: "employmentDetails_RegistrationDate",
                table: "Employees",
                newName: "FechaDeRegistro");

            migrationBuilder.AddColumn<bool>(
                name: "Asegurado",
                table: "Employees",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Estatus",
                table: "Employees",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace StaffManagementSystem.Server.Models
{
    /// <summary>
    /// Represents an employee in the staff management system.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the social security number of the employee.
        /// </summary>
        [Key]
        public int? SocialSecurityNumber { get; set; }

        /// <summary>
        /// Gets or sets the RFC (Registro Federal de Contribuyentes) of the employee.
        /// </summary>
        public string? RFC { get; set; }

        /// <summary>
        /// Gets or sets the CURP (Clave Única de Registro de Población) of the employee.
        /// </summary>
        public string? CURP { get; set; }

        /// <summary>
        /// Gets or sets the first name of the employee.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the middle name of the employee.
        /// </summary>
        public string? MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the employee.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the second last name of the employee.
        /// </summary>
        public string? SecondLastname { get; set; }

        /// <summary>
        /// Gets or sets the birth date of the employee.
        /// </summary>
        public DateOnly BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the gender of the employee.
        /// </summary>
        public string? Gender { get; set; }

        /// <summary>
        /// Gets or sets the blood type of the employee.
        /// </summary>
        public string? BloodType { get; set; }

        /// <summary>
        /// Gets or sets the marital status of the employee.
        /// </summary>
        public string? MaritalStatus { get; set; }

        /// <summary>
        /// Gets or sets the number of children of the employee.
        /// </summary>
        public int? Children { get; set; }


        /// <summary>
        /// Gets or sets the contact information of the employee.
        /// </summary>
        public ContactInfo ContactInfo { get; set; }

        /// <summary>
        /// Gets or sets the address of the employee.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Gets or sets the employment details of the employee.
        /// </summary>
        public EmploymentDetails EmploymentDetails { get; set; }

        /// <summary>
        /// Gets or sets the emergency contact information of the employee.
        /// </summary>
        public EmergencyContact EmergencyContact { get; set; }
    }

    /// <summary>
    /// Represents the address of an employee.
    /// </summary>
    [Owned]
    public class Address
    {
        /// <summary>
        /// Gets or sets the address line of the employee.
        /// </summary>
        public string? Street { get; set; }

        /// <summary>
        /// Gets or sets the house number of the employee.
        /// </summary>
        public string? Number { get; set; }

        /// <summary>
        /// Gets or sets the postal code of the employee.
        /// </summary>
        public string? PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the neighborhood of the employee.
        /// </summary>
        public string? Neighborhood { get; set; }

        /// <summary>
        /// Gets or sets the city of the employee.
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// Gets or sets the state of the employee.
        /// </summary>
        public string? State { get; set; }
    }

    /// <summary>
    /// Represents the contact information of an employee.
    /// </summary>
    [Owned]
    public class ContactInfo
    {
        /// <summary>
        /// Gets or sets the email address of the employee.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the employee.
        /// </summary>

        public string? PhoneNumber { get; set; }
    }

    /// <summary>
    /// Represents the employment details of an employee.
    /// </summary>
    [Owned]
    public class EmploymentDetails
    {

        /// <summary>
        /// Gets or sets the position of the employee.
        /// </summary>
        public string? Position { get; set; }

        /// <summary>
        /// Gets or sets the department of the employee.
        /// </summary>
        public string? Department { get; set; }

        // Employment Dates
        /// <summary>
        /// Gets or sets the date of joining of the employee.
        /// </summary>
        public DateOnly? DateOfJoining { get; set; }

        /// <summary>
        /// Gets or sets the hiring date of the employee.
        /// </summary>
        public DateOnly? HiringDate { get; set; }

        /// <summary>
        /// Gets or sets the resignation date of the employee.
        /// </summary>
        [AllowNull]
        public DateOnly? ResignationDate { get; set; }

        // Supervision and Shift Information

        /// <summary>
        /// Gets or sets the direct boss name of the employee.
        /// </summary>
        public string? BossName { get; set; }

        /// <summary>
        /// Gets or sets the shift of the employee.
        /// </summary>
        public string? Shift { get; set; }

        // Hiring Information
        /// <summary>
        /// Gets or sets the name of the enterprise who hired the employee.
        /// </summary>
        public string? HiredBy { get; set; }

        /// <summary>
        /// Gets or sets the study grade of the employee.
        /// </summary>
        public string? StudyGrade { get; set; }

        // Financial Information
        /// <summary>
        /// Gets or sets the salary of the employee.
        /// </summary>
        public decimal? Salary { get; set; }

        /// <summary>
        /// Gets or sets the bank name of the employee.
        /// </summary>
        public string? BankName { get; set; }


        /// <summary>
        /// Gets or sets the bank account number of the employee.
        /// </summary>
        public string? InterbankClabe { get; set; }

        /// <summary>
        /// Gets or sets the bank account number of the employee, specific for the BBVA bank.s
        /// </summary>
        public string? BankAccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the payment frequency of the employee.
        /// </summary>
        public string? PaymentFrequency { get; set; }

        /// <summary>
        /// Gets or sets the payroll type of the employee.
        /// </summary>
        public string? PayrollType { get; set; }

        // Status Information


        /// <summary>
        /// Gets or sets a value indicating whether the employee is active.
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the employee has active insurance.
        /// </summary>
        public bool? InsuranceActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the employee's file is complete.
        /// </summary>
        public bool? IsFileComplete { get; set; }

        /// <summary>
        /// Gets or sets the birth certificate status of the employee if he have delivered it.
        /// </summary>
        public bool? BirthCertificate { get; set; }

        /// <summary>
        /// Gets or sets the job application status of the employee if he have delivered it.
        /// </summary>
        public bool? JobApplication { get; set; }

        /// <summary>
        /// Gets or sets the no criminal record certificate status of the employee.
        /// </summary>
        public bool? NoCriminalRecordCertificate { get; set; }

        /// <summary>
        /// Gets or sets the INE of the employee if he have delivered it.
        /// </summary>
        public bool? INE { get; set; }

        /// <summary>
        /// Gets or sets the INE number of the employee.
        /// 
        public string? INENumber { get; set; }


        // Additional Information

        /// <summary>
        /// Gets or sets the registration date of the employee in the system.
        /// </summary>
        public DateOnly? RegistrationDate { get; set; }

        /// <summary>
        /// Gets or sets the notes for the employee.
        /// </summary>
        public string? Notes { get; set; }
    }



    /// <summary>
    /// Represents the emergency contact information of an employee.
    /// </summary>
    [Owned]
    public class EmergencyContact
    {
        /// <summary>
        /// Gets or sets the name of the emergency contact.
        /// </summary>
        public string? EmergencyContactName { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the emergency contact.
        /// </summary>
        public string? EmergencyPhone { get; set; }

        /// <summary>
        /// Gets or sets the relationship of the emergency contact to the employee.
        /// </summary>
        public string? EmergencyRelationship { get; set; }
    }
}

// Todo: Set required fields in the model after joining the information of the employees
// Todo: Add validation attributes to the model properties to ensure data integrity
// Todo: Dont allow null values in the model properties once the data is joined
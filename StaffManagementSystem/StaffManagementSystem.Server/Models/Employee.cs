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
        public int SocialSecurityNumber { get; set; }

        /// <summary>
        /// Gets or sets the RFC (Registro Federal de Contribuyentes) of the employee.
        /// </summary>
        [StringLength(13, MinimumLength = 13, ErrorMessage = "The field {0} must be a string with a length of {1}.")]
        public string RFC { get; set; }

        /// <summary>
        /// Gets or sets the CURP (Clave Única de Registro de Población) of the employee.
        /// </summary>
        [StringLength(18, MinimumLength = 18, ErrorMessage = "The field {0} must be a string with a length of {1}.")]
        public string CURP { get; set; }

        /// <summary>
        /// Gets or sets the first name of the employee.
        /// </summary>
        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the middle name of the employee.
        /// </summary>
        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        public string? MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the employee.
        /// </summary>
        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the second last name of the employee.
        /// </summary>
        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        public string? SecondLastname { get; set; }

        /// <summary>
        /// Gets or sets the birth date of the employee.
        /// </summary>
        public DateOnly BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the gender of the employee.
        /// </summary>
        [StringLength(10, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the blood type of the employee.
        /// </summary>
        [StringLength(10, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        public string BloodType { get; set; }

        /// <summary>
        /// Gets or sets the marital status of the employee.
        /// </summary>
        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        public string MaritalStatus { get; set; }

        /// <summary>
        /// Gets or sets the number of children of the employee.
        /// </summary>
        [Range(0, 20, ErrorMessage = "The field {0} must be between {1} and {2}.")]
        public int Children { get; set; }


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
        [StringLength(200, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the house number of the employee.
        /// </summary>
        [StringLength(10, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the postal code of the employee.
        /// </summary>
        [StringLength(10, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "The field {0} must be a valid postal code.")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the neighborhood of the employee.
        /// </summary>
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string Neighborhood { get; set; }

        /// <summary>
        /// Gets or sets the city of the employee.
        /// </summary>
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state of the employee.
        /// </summary>
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string State { get; set; }
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
        [EmailAddress(ErrorMessage = "The field {0} must be a valid email address.")]
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the employee.
        /// </summary>
        [Phone(ErrorMessage = "The field {0} must be a valid phone number.")]
        [StringLength(20, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string PhoneNumber { get; set; }
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
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string Position { get; set; }

        /// <summary>
        /// Gets or sets the department of the employee.
        /// </summary>
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string Department { get; set; }

        // Employment Dates
        /// <summary>
        /// Gets or sets the date of joining of the employee.
        /// </summary>
        public DateOnly DateOfJoining { get; set; }

        /// <summary>
        /// Gets or sets the hiring date of the employee.
        /// </summary>
        public DateTime HiringDate { get; set; }

        /// <summary>
        /// Gets or sets the resignation date of the employee.
        /// </summary>
        [AllowNull]
        public DateTime? ResignationDate { get; set; }

        // Supervision and Shift Information

        /// <summary>
        /// Gets or sets the direct boss name of the employee.
        /// </summary>
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string BossName { get; set; }

        /// <summary>
        /// Gets or sets the shift of the employee.
        /// </summary>
        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string Shift { get; set; }

        // Hiring Information
        /// <summary>
        /// Gets or sets the name of the enterprise who hired the employee.
        /// </summary>
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string HiredBy { get; set; }

        /// <summary>
        /// Gets or sets the study grade of the employee.
        /// </summary>
        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        public string? StudyGrade { get; set; }

        // Financial Information
        /// <summary>
        /// Gets or sets the salary of the employee.
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "The field {0} must be a positive number.")]
        public decimal Salary { get; set; }

        /// <summary>
        /// Gets or sets the bank name of the employee.
        /// </summary>
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string? BankName { get; set; }


        /// <summary>
        /// Gets or sets the bank account number of the employee.
        /// </summary>
        [StringLength(18, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string? InterbankClabe { get; set; }

        /// <summary>
        /// Gets or sets the payment frequency of the employee.
        /// </summary>
        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string? PaymentFrequency { get; set; }

        /// <summary>
        /// Gets or sets the payroll type of the employee.
        /// </summary>
        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string? PayrollType { get; set; }

        // Status Information


        /// <summary>
        /// Gets or sets a value indicating whether the employee is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the employee has active insurance.
        /// </summary>
        public bool InsuranceActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the employee's file is complete.
        /// </summary>
        public bool IsFileComplete { get; set; }

        /// <summary>
        /// Gets or sets the birth certificate status of the employee if he have delivered it.
        /// </summary>
        public bool BirthCertificate { get; set; }

        /// <summary>
        /// Gets or sets the no criminal record certificate status of the employee.
        /// </summary>
        public bool NoCriminalRecordCertificate { get; set; }

        /// <summary>
        /// Gets or sets the INE of the employee if he have delivered it.
        /// </summary>
        [StringLength(18, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        public bool? INE { get; set; }

        // Additional Information

        /// <summary>
        /// Gets or sets the registration date of the employee in the system.
        /// </summary>
        public DateTime? RegistrationDate { get; set; }

        /// <summary>
        /// Gets or sets the notes for the employee.
        /// </summary>
        [StringLength(500, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string Notes { get; set; }
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
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string EmergencyContactName { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the emergency contact.
        /// </summary>
        [Phone(ErrorMessage = "The field {0} must be a valid phone number.")]
        [StringLength(15, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string EmergencyPhone { get; set; }

        /// <summary>
        /// Gets or sets the relationship of the emergency contact to the employee.
        /// </summary>
        [AllowNull]
        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string? EmergencyRelationship { get; set; }
    }
}
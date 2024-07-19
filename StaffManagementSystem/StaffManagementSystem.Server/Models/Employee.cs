using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

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
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "The field {0} must be a string with a length of {1}.")]
        public string RFC { get; set; }

        /// <summary>
        /// Gets or sets the CURP (Clave Única de Registro de Población) of the employee.
        /// </summary>
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "The field {0} must be a string with a length of {1}.")]
        public string CURP { get; set; }

        /// <summary>
        /// Gets or sets the first name of the employee.
        /// </summary>
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the middle name of the employee.
        /// </summary>
        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        [AllowNull]
        public string? MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the employee.
        /// </summary>
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the second last name of the employee.
        /// </summary>
        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        [AllowNull]
        public string? SecondLastname { get; set; }

        /// <summary>
        /// Gets or sets the birth date of the employee.
        /// </summary>
        [Required(ErrorMessage = "The field {0} is required.")]
        [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "The field {0} must be a valid date.")]
        public DateOnly BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the gender of the employee.
        /// </summary>
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(10, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the blood type of the employee.
        /// </summary>
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(10, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        public String BloodType { get; set; }

        /// <summary>
        /// Gets or sets the marital status of the employee.
        /// </summary>
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        public string MaritalStatus { get; set; }

        /// <summary>
        /// Gets or sets the number of children of the employee.
        /// </summary>
        [Required(ErrorMessage = "The field {0} is required.")]
        [Range(0, 20, ErrorMessage = "The field {0} must be between {1} and {2}.")]
        public int Children { get; set; }

        /// <summary>
        /// Gets or sets the study grade of the employee.
        /// </summary>
        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        [AllowNull]
        public string? StudyGrade { get; set; }

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
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(200, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string AddressLine { get; set; }

        /// <summary>
        /// Gets or sets the postal code of the employee.
        /// </summary>
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(10, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "The field {0} must be a valid postal code.")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the neighborhood of the employee.
        /// </summary>
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string Neighborhood { get; set; }

        /// <summary>
        /// Gets or sets the city of the employee.
        /// </summary>
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state of the employee.
        /// </summary>
        [Required(ErrorMessage = "The field {0} is required.")]
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
        [Required(ErrorMessage = "The field {0} is required.")]
        [EmailAddress(ErrorMessage = "The field {0} must be a valid email address.")]
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the employee.
        /// </summary>
        [Required(ErrorMessage = "The field {0} is required.")]
        [Phone(ErrorMessage = "The field {0} must be a valid phone number.")]
        [StringLength(15, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string PhoneNumber { get; set; }
    }

    /// <summary>
    /// Represents the employment details of an employee.
    /// </summary>
    [Owned]
    public class EmploymentDetails
    {
        /// <summary>
        /// Gets or sets the hiring date of the employee.
        /// </summary>
        [Required(ErrorMessage = "The field {0} is required.")]
        public DateTime HiringDate { get; set; }

        /// <summary>
        /// Gets or sets the resignation date of the employee.
        /// </summary>
        [AllowNull]
        public DateTime? ResignationDate { get; set; }

        /// <summary>
        /// Gets or sets the department of the employee.
        /// </summary>
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string Department { get; set; }

        /// <summary>
        /// Gets or sets the position of the employee.
        /// </summary>
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string Position { get; set; }

        /// <summary>
        /// Gets or sets the boss name of the employee.
        /// </summary>
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string BossName { get; set; }

        /// <summary>
        /// Gets or sets the shift of the employee.
        /// </summary>
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string Shift { get; set; }

        /// <summary>
        /// Gets or sets the name of the person who hired the employee.
        /// </summary>
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string HiredBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the employee is active.
        /// </summary>
        [Required(ErrorMessage = "The field {0} is required.")]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the employee has active insurance.
        /// </summary>
        [Required(ErrorMessage = "The field {0} is required.")]
        public bool InsuranceActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the employee's file is complete.
        /// </summary>
        [Required(ErrorMessage = "The field {0} is required.")]
        public bool IsFileComplete { get; set; }

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
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string EmergencyContactName { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the emergency contact.
        /// </summary>
        [Required(ErrorMessage = "The field {0} is required.")]
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

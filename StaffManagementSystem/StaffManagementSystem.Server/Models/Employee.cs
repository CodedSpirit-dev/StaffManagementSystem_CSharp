using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

namespace StaffManagementSystem.Server.Models
{
    public class Employee
    {
        [Key]
        public int SocialSecurityNumber { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(13, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        public string RFC { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(18, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        public string CURP { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        [AllowNull]
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        public string LastName { get; set; }

        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        [AllowNull]
        public string? SecondLastname { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        public DateOnly BirthDate { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(10, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(10, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        public String BloodType { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        public string MaritalStatus { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [Range(0, 20, ErrorMessage = "The field {0} must be between {1} and {2}.")]
        public int Children { get; set; }

        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        [AllowNull]
        public string? StudyGrade { get; set; }

        public ContactInfo ContactInfo { get; set; }
        public Address Address { get; set; }
        public EmploymentDetails EmploymentDetails { get; set; }
        public EmergencyContact EmergencyContact { get; set; }
    }

    [Owned]
    public class Address
    {
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(200, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string AddressLine { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(10, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "The field {0} must be a valid postal code.")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string State { get; set; }
    }

    [Owned]
    public class ContactInfo
    {
        [Required(ErrorMessage = "The field {0} is required.")]
        [EmailAddress(ErrorMessage = "The field {0} must be a valid email address.")]
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [Phone(ErrorMessage = "The field {0} must be a valid phone number.")]
        [StringLength(15, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string PhoneNumber { get; set; }
    }

    [Owned]
    public class EmploymentDetails
    {
        [Required(ErrorMessage = "The field {0} is required.")]
        public DateTime HiringDate { get; set; }
        [AllowNull]
        public DateTime? ResignationDate { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string Department { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string Position { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string BossName { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string Shift { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string HiredBy { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        public bool InsuranceActive { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        public bool IsFileComplete { get; set; }
        [StringLength(500, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string Notes { get; set; }
    }

    [Owned]
    public class EmergencyContact
    {
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string EmergencyContactName { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [Phone(ErrorMessage = "The field {0} must be a valid phone number.")]
        [StringLength(15, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string EmergencyPhone { get; set; }

        [AllowNull]
        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string? EmergencyRelationship { get; set; }
    }
}

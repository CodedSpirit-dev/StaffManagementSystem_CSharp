using System;
using System.ComponentModel.DataAnnotations;

namespace StaffTemplate.server.Models
{
    public class Employee
    {
        [Key]
        [StringLength(11, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
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
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        public string LastName { get; set; }

        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        public string? SecondLastname { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        public DateOnly BirthDate { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(10, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        public string MaritalStatus { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [Range(0, 20, ErrorMessage = "The field {0} must be between {1} and {2}.")]
        public int Children { get; set; }

        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1}.")]
        public string StudyGrade { get; set; }

        // Navigation properties
        public ContactInfo ContactInfo { get; set; }
        public Address Address { get; set; }
        public EmploymentDetails EmploymentDetails { get; set; }
        public EmergencyContact EmergencyContact { get; set; }
    }
}

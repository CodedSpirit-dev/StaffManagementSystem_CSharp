using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace StaffTemplate.server.Models
{
    public class Employee
    {
        [Key]
        public int SocialSecurityNumber { get; set; }
        [Required]
        public string RFC { get; set; }
        [Required]
        public string CURP { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string SecondLastname { get; set; }
        [Required]
        public DateOnly BirthDate { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string MaritalStatus { get; set; }
        [Required]
        public int Children { get; set; }
        [Required]
        public string StudyGrade { get; set; }

        // Navigation properties
        public ContactInfo ContactInfo { get; set; }
        public Address Address { get; set; }
        public EmploymentDetails EmploymentDetails { get; set; }
        public EmergencyContact EmergencyContact { get; set; }
    }
}

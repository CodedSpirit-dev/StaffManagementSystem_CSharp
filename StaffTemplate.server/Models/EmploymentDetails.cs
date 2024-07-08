using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffTemplate.server.Models
{
    public class EmploymentDetails
    {
        [Key, ForeignKey("Employee")]
        public int SocialSecurityNumber { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        public DateTime HiringDate { get; set; }

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
        public bool IsFileComplete { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(500, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string Notes { get; set; }

        // Navigation properties
        public Employee Employee { get; set; }
    }
}

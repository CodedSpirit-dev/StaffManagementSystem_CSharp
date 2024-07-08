using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffTemplate.server.Models
{
    public class EmploymentDetails
    {
        [Key, ForeignKey("Employee")]
        public int SocialSecurityNumber { get; set; }
        [Required]
        public DateTime HiringDate { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string BossName { get; set; }
        [Required]
        public string Shift { get; set; }
        [Required]
        public string HiredBy { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public bool IsFileComplete { get; set; }
        [Required]
        public string Notes { get; set; }

        // Navigation properties
        public Employee Employee { get; set; }
    }
}

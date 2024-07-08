using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffTemplate.server.Models
{
    public class EmergencyContact
    {
        [Key, ForeignKey("Employee")]
        public int SocialSecurityNumber { get; set; }
        [Required]
        public string EmergencyContactName { get; set; }
        [Required]
        public string EmergencyPhone { get; set; }
        [Required]
        public string EmergencyRelationship { get; set; }

        // Navigation properties
        public Employee Employee { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffTemplate.server.Models
{
    public class ContactInfo
    {
        [Key, ForeignKey("Employee")]
        public int SocialSecurityNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        // Navigation properties
        public Employee Employee { get; set; }
    }
}

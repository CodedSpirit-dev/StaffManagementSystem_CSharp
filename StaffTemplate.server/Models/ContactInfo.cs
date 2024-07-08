using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffTemplate.server.Models
{
    public class ContactInfo
    {
        [Key, ForeignKey("Employee")]
        public int SocialSecurityNumber { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [EmailAddress(ErrorMessage = "The field {0} must be a valid email address.")]
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [Phone(ErrorMessage = "The field {0} must be a valid phone number.")]
        [StringLength(15, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string PhoneNumber { get; set; }

        // Navigation properties
        public Employee Employee { get; set; }
    }
}

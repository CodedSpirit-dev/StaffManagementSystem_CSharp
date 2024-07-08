using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffTemplate.server.Models
{
    public class Address
    {
        [Key, ForeignKey("Employee")]
        public int SocialSecurityNumber { get; set; }

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

        // Navigation properties
        public Employee Employee { get; set; }
    }
}

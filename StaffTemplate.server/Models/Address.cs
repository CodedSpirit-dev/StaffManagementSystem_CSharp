using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffTemplate.server.Models
{
    public class Address
    {
        [Key, ForeignKey("Employee")]
        public int SocialSecurityNumber { get; set; }
        [Required]
        public string AddressLine { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Neighborhood { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }

        // Navigation properties
        public Employee Employee { get; set; }
    }
}

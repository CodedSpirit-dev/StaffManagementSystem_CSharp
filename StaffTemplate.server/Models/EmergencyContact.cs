using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffTemplate.server.Models
{
    public class EmergencyContact
    {
        [Key]
        //Generate UUID
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmergencyContactId { get; set; }
        [ForeignKey("Employee")]
        public int SocialSecurityNumber { get; set; }
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(100, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string EmergencyContactName { get; set; }
        [Required(ErrorMessage = "The field {0} is required.")]
        [Phone(ErrorMessage = "The field {0} must be a valid phone number.")]
        [StringLength(15, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string EmergencyPhone { get; set; }
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(50, ErrorMessage = "The field {0} must be a string with a maximum length of {1} characters.")]
        public string EmergencyRelationship { get; set; }
        public Employee Employee { get; set; }
    }
}

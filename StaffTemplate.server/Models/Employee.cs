using System.ComponentModel.DataAnnotations;

namespace StaffTemplate.server.Models
{
    public class Employee
    {
        [Required]
        public String FirstName;
        [Required]
        public String MiddleName;
        [Required]
        public String LastName;
        [Required]
        public String SecondLastname;
        [Key]
        public int SocialSecurityNumber;


    }
}

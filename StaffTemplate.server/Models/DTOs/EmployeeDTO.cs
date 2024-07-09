namespace StaffTemplate.server.Models.DTOs
{
    public class EmployeeDTO
    {
        public int SocialSecurityNumber { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string? SecondLastname { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public int Children { get; set; }
        public string StudyGrade { get; set; }
        public ContactInfoDTO ContactInfo { get; set; }
        public AddressDTO Address { get; set; }
        public EmploymentDetailsDTO EmploymentDetails { get; set; }
        public EmergencyContactDTO EmergencyContact { get; set; }
    }

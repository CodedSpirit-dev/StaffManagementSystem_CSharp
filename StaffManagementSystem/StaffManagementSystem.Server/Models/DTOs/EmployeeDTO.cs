namespace StaffManagementSystem.Server.Models.DTOs
{
    public class EmployeeDTO
    {
        public int SocialSecurityNumber { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SecondLastname { get; set; }
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

    public class AddressDTO
    {
        public string AddressLine { get; set; }
        public string PostalCode { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }

    public class ContactInfoDTO
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class EmploymentDetailsDTO
    {
        public DateTime HiringDate { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string BossName { get; set; }
        public string Shift { get; set; }
        public string HiredBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsFileComplete { get; set; }
        public string Notes { get; set; }
    }

    public class EmergencyContactDTO
    {
        public string EmergencyContactName { get; set; }
        public string EmergencyPhone { get; set; }
        public string EmergencyRelationship { get; set; }
    }
}
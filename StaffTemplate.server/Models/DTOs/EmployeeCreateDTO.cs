using StaffTemplate.server.Models.DTOs;

public class EmployeeCreateDTO
{
    public EmployeeDTO Employee { get; set; }
    public AddressDTO Address { get; set; }
    public EmergencyContactDTO EmergencyContact { get; set; }
    public ContactInfoDTO ContactInfo { get; set; }
    public EmploymentDetailsDTO EmploymentDetails { get; set; }
}

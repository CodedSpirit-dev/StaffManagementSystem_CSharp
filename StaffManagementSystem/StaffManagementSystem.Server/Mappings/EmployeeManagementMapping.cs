using AutoMapper;
using StaffManagementSystem.Server.Models;
using StaffManagementSystem.Server.Models.DTOs;

namespace StaffTemplate.server.Mappings
{
    /// <summary>
    /// Represents the mapping configuration for employee management.
    /// </summary>
    public class EmployeeManagementMapping : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeManagementMapping"/> class.
        /// </summary>
        public EmployeeManagementMapping()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<ContactInfo, ContactInfoDTO>().ReverseMap();
            CreateMap<EmergencyContact, EmergencyContactDTO>().ReverseMap();
            CreateMap<EmploymentDetails, EmploymentDetailsDTO>().ReverseMap();
        }
    }
}

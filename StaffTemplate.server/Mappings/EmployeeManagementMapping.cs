using AutoMapper;
using StaffTemplate.server.Models;
using StaffTemplate.server.Models.DTOs;

namespace StaffTemplate.server.Mappings
{
    public class EmployeeManagementMapping : Profile
    {
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

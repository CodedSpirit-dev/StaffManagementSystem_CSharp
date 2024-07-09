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
            CreateMap<EmploymentDetailsDTO, EmploymentDetails>()
                .ForMember(dest => dest.SocialSecurityNumber, opt => opt.Ignore()) // Opcional si no se asigna directamente desde DTO
                .ForMember(dest => dest.Employee, opt => opt.Ignore()); // Opcional si no se asigna directamente desde DTO
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<ContactInfo, ContactInfoDTO>().ReverseMap();
            CreateMap<EmergencyContact, EmergencyContactDTO>().ReverseMap();
        }
    }
}

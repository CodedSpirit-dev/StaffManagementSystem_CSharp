using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StaffTemplate.server.Models;
using StaffTemplate.server.Repository.IRepository;
using StaffTemplate.server.Models.DTOs;

namespace StaffTemplate.server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] EmployeeCreateDTO employeeCreateDTO)
        {
            if (employeeCreateDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (_employeeRepository.EmployeeExists(employeeCreateDTO.Employee.SocialSecurityNumber))
            {
                ModelState.AddModelError("", "Employee Exists!");
                return StatusCode(404, ModelState);
            }

            var employeeObj = _mapper.Map<Employee>(employeeCreateDTO.Employee);
            var addressObj = _mapper.Map<Address>(employeeCreateDTO.Address);
            var emergencyContactObj = _mapper.Map<EmergencyContact>(employeeCreateDTO.EmergencyContact);
            var contactInfoObj = _mapper.Map<ContactInfo>(employeeCreateDTO.ContactInfo);
            var employmentDetailsObj = _mapper.Map<EmploymentDetails>(employeeCreateDTO.EmploymentDetails);

            if (!_employeeRepository.CreateEmployee(employeeObj, addressObj, emergencyContactObj, contactInfoObj, employmentDetailsObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {employeeObj.FirstName}");
                return StatusCode(500, ModelState);
            }

            return Ok(employeeObj);
        }
    }
}

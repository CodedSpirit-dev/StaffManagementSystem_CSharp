using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StaffTemplate.server.Models;
using StaffTemplate.server.Models.DTOs;
using StaffTemplate.server.Repository;
using StaffTemplate.server.Repository.IRepository;
using StaffTemplate.server.Services;

namespace StaffTemplate.server.Controllers
{
    [Route("/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeRepository = _employeeRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(EmployeeDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [HttpPost]
        public IActionResult CreateEmployee([FromBody] EmployeeDTO employeeDTO, AddressDTO addressDTO, EmergencyContactDTO emergencyContactDTO, ContactInfoDTO contactInfoDTO,
            EmploymentDetailsDTO employmentDetailsDTO)
        {
            if (employeeDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (_employeeRepository.EmployeeExists(employeeDTO.SocialSecurityNumber))
            {
                ModelState.AddModelError("", "Employee Exists!");
                return StatusCode(404, ModelState);
            }

            var employeeObj = new Employee
            {
                RFC = employeeDTO.RFC,
                CURP = employeeDTO.CURP,
                FirstName = employeeDTO.FirstName,
                MiddleName = employeeDTO.MiddleName,
                LastName = employeeDTO.LastName,
                SecondLastname = employeeDTO.SecondLastname,
                BirthDate = employeeDTO.BirthDate,
                Gender = employeeDTO.Gender,
                MaritalStatus = employeeDTO.MaritalStatus,
                Children = employeeDTO.Children,
                StudyGrade = employeeDTO.StudyGrade,
                SocialSecurityNumber = employeeDTO.SocialSecurityNumber,
                
            };

            var addressObj = new Address
            {
                AddressLine = addressDTO.AddressLine,
                PostalCode = addressDTO.PostalCode,
                Neighborhood = addressDTO.Neighborhood,
                City = addressDTO.City,
                State = addressDTO.State
            };

            var emergencyContactObj = new EmergencyContact
            {
                EmergencyContactName = emergencyContactDTO.EmergencyContactName,
                EmergencyPhone = emergencyContactDTO.EmergencyPhone,
                EmergencyRelationship = emergencyContactDTO.EmergencyRelationship
            };

            var contactInfoObj = new ContactInfo
            {
                Email = contactInfoDTO.Email,
                PhoneNumber = contactInfoDTO.PhoneNumber,
            };

            var EmploymentDetailsObj = new EmploymentDetails
            {
                Position = employmentDetailsDTO.Position,
                Department = employmentDetailsDTO.Department,
                HiringDate = employmentDetailsDTO.HiringDate,
                BossName = employmentDetailsDTO.BossName,
                Shift = employmentDetailsDTO.Shift,
                HiredBy = employmentDetailsDTO.HiredBy,
                IsActive = employmentDetailsDTO.IsActive,
                IsFileComplete = employmentDetailsDTO.IsFileComplete,
                Notes = employmentDetailsDTO.Notes,
                Employee = employeeObj
            };
            // Inicializa otros objetos relacionados aquí, como ContactInfo y EmploymentDetails

            if (!_employeeRepository.CreateEmployee(employeeObj, addressObj, emergencyContactObj, contactInfoObj, EmploymentDetailsObj /*, otros objetos */))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {employeeObj.FirstName}");
                return StatusCode(500, ModelState);
            }

            return Ok(employeeObj);
        }


        }
    }
    

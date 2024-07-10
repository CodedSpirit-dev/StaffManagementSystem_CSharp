using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffTemplate.server.Models;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly EmployeeService _employeeService;

    public EmployeesController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EmployeeCreateDTO employeeCreateDTO)
    {
        if (ModelState.IsValid)
        {
            var employee = new Employee
            {
                SocialSecurityNumber = employeeCreateDTO.Employee.SocialSecurityNumber,
                RFC = employeeCreateDTO.Employee.RFC,
                CURP = employeeCreateDTO.Employee.CURP,
                FirstName = employeeCreateDTO.Employee.FirstName,
                MiddleName = employeeCreateDTO.Employee.MiddleName,
                LastName = employeeCreateDTO.Employee.LastName,
                SecondLastname = employeeCreateDTO.Employee.SecondLastname,
                BirthDate = employeeCreateDTO.Employee.BirthDate,
                Gender = employeeCreateDTO.Employee.Gender,
                MaritalStatus = employeeCreateDTO.Employee.MaritalStatus,
                Children = employeeCreateDTO.Employee.Children,
                StudyGrade = employeeCreateDTO.Employee.StudyGrade,
                ContactInfo = new ContactInfo
                {
                    Email = employeeCreateDTO.ContactInfo.Email,
                    PhoneNumber = employeeCreateDTO.ContactInfo.PhoneNumber
                },
                Address = new Address
                {
                    AddressLine = employeeCreateDTO.Address.AddressLine,
                    PostalCode = employeeCreateDTO.Address.PostalCode,
                    Neighborhood = employeeCreateDTO.Address.Neighborhood,
                    City = employeeCreateDTO.Address.City,
                    State = employeeCreateDTO.Address.State
                },
                EmploymentDetails = new EmploymentDetails
                {
                    HiringDate = employeeCreateDTO.EmploymentDetails.HiringDate,
                    Department = employeeCreateDTO.EmploymentDetails.Department,
                    Position = employeeCreateDTO.EmploymentDetails.Position,
                    BossName = employeeCreateDTO.EmploymentDetails.BossName,
                    Shift = employeeCreateDTO.EmploymentDetails.Shift,
                    HiredBy = employeeCreateDTO.EmploymentDetails.HiredBy,
                    IsActive = employeeCreateDTO.EmploymentDetails.IsActive,
                    IsFileComplete = employeeCreateDTO.EmploymentDetails.IsFileComplete,
                    Notes = employeeCreateDTO.EmploymentDetails.Notes
                },
                EmergencyContact = new EmergencyContact
                {
                    EmergencyContactName = employeeCreateDTO.EmergencyContact.EmergencyContactName,
                    EmergencyPhone = employeeCreateDTO.EmergencyContact.EmergencyPhone,
                    EmergencyRelationship = employeeCreateDTO.EmergencyContact.EmergencyRelationship
                }
            };

            await _employeeService.InsertEmployeeAsync(employee);

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.SocialSecurityNumber }, employee);
        }

        return BadRequest(ModelState);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployee(int id)
    {
        var employee = await _context.Employees
            .Include(e => e.ContactInfo)
            .Include(e => e.Address)
            .Include(e => e.EmploymentDetails)
            .Include(e => e.EmergencyContact)
            .FirstOrDefaultAsync(e => e.SocialSecurityNumber == id);

        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }
}

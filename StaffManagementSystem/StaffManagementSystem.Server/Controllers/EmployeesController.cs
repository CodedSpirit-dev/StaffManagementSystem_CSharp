using Microsoft.AspNetCore.Mvc;
using StaffManagementSystem.Server.Models;
using StaffTemplate.Shared.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StaffTemplate.server.Data;

namespace StaffTemplate.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ApplicationDbContext _context;

        public EmployeesController(IEmployeeService employeeService, ApplicationDbContext context)
        {
            _employeeService = employeeService;
            _context = context;
        }

        [HttpGet(Name = "GetEmployees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            return Ok(employees);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Employee>> CreateEmployee([FromForm] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Establecer isActive como true si no está presente
            if (!employee.EmploymentDetails.IsActive)
            {
                employee.EmploymentDetails.IsActive = true;
            }
            {
                employee.EmploymentDetails.IsActive = true;
            }

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _employeeService.InsertEmployeeAsync(employee);
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    return StatusCode(500, "Internal server error");
                }
            }

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.SocialSecurityNumber }, employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromForm] int id, Employee employee)
        {
            if (id != employee.SocialSecurityNumber)
            {
                return BadRequest();
            }

            if (employee.EmploymentDetails.IsActive == false && !employee.EmploymentDetails.IsActive && employee.EmploymentDetails.ResignationDate == null)
            {
                employee.EmploymentDetails.ResignationDate = DateTime.Now;
            }

            _context.Entry(employee).State = EntityState.Modified;

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }
                }
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.SocialSecurityNumber == id);
        }
    }
}

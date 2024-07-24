using Microsoft.AspNetCore.Mvc;
using StaffManagementSystem.Server.Models;
using StaffTemplate.Shared.Services;
using Microsoft.EntityFrameworkCore;
using StaffTemplate.Server.Data;

namespace StaffTemplate.Server.Controllers
{
    /// <summary>
    /// Controller for managing employees.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeesController"/> class.
        /// </summary>
        /// <param name="employeeService">The employee service.</param>
        /// <param name="context">The application database context.</param>
        public EmployeesController(IEmployeeService employeeService, ApplicationDbContext context)
        {
            _employeeService = employeeService;
            _context = context;
        }

        /// <summary>
        /// Gets the list of all employees.
        /// </summary>
        /// <returns>The list of employees.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            return Ok(employees);
        }

        /// <summary>
        /// Gets an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <returns>The employee.</returns>
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

        /// <summary>
        /// Creates a new employee.
        /// </summary>
        /// <param name="employee">The employee to create.</param>
        /// <returns>The created employee.</returns>
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!employee.EmploymentDetails.IsActive == null)
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

        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        /// <param name="id">The ID of the employee to update.</param>
        /// <param name="employee">The updated employee data.</param>
        /// <returns>The updated employee.</returns>
        [HttpPatch("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (id != employee.SocialSecurityNumber)
            {
                return BadRequest("ID mismatch");
            }

            if (EmployeeExists(id) == false)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _employeeService.UpdateEmployeeAsync(employee);
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

            return Ok(employee);
        }

        /// <summary>
        /// Deactivates an existing employee.
        /// </summary>
        /// <param name="id">The ID of the employee to deactivate.</param>
        /// <returns>The deactivated employee.</returns>
        [HttpPatch("{id}/deactivate")]
        public async Task<ActionResult<Employee>> DeactivateEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            if (employee.EmploymentDetails.IsActive = false) // Change to Active
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        await _employeeService.UpdateEmployeeAsync(employee);
                        await transaction.CommitAsync();
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        return StatusCode(500, $"Internal server error: {ex.Message}");
                    }
                }

            } else
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        await _employeeService.UpdateEmployeeAsync(employee);
                        await transaction.CommitAsync();
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        return StatusCode(500, $"Internal server error: {ex.Message}");
                    }
                }
            }





            return Ok(employee);
        }

        /// <summary>
        /// Checks if an employee exists by ID.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <returns>True if the employee exists, otherwise false.</returns>
        [HttpGet("exists/{id}")]
        public bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.SocialSecurityNumber == id);
        }
    }
}

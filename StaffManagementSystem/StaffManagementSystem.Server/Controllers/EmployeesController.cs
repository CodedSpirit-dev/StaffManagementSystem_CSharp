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
        [HttpGet(Name = "GetEmployees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            return Ok(employees);
        }

        /// <summary>
        /// Creates a new employee.
        /// </summary>
        /// <param name="employee">The employee to create.</param>
        /// <returns>The created employee.</returns>
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Employee>> CreateEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Stablish the employee as active if it is not.
            if (!employee.EmploymentDetails.IsActive)
            {
                employee.EmploymentDetails.IsActive = true;
            }
            {
                employee.EmploymentDetails.IsActive = true;
            }

            // Set the hiring date to the current date if it is not set.
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

            // Return the created employee.
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.SocialSecurityNumber }, employee);
        }

        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        /// <param name="id">The ID of the employee to update.</param>
        /// <param name="employee">The updated employee data.</param>
        /// <returns>The updated employee.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromBody] int id, Employee employee)
        {
            if (id != employee.SocialSecurityNumber)
            {
                return BadRequest();
            }

            // Set the resignation date to the current date if the employee is not active and the resignation date is not set.
            if (employee.EmploymentDetails.IsActive == false && !employee.EmploymentDetails.IsActive && employee.EmploymentDetails.ResignationDate == null)
            {
                employee.EmploymentDetails.ResignationDate = DateTime.Now;
            }


            // Update the employee.
            _context.Entry(employee).State = EntityState.Modified;


            // Save the changes.
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


            // Return the updated employee.
            return NoContent();
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

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.SocialSecurityNumber == id);
        }
    }
}

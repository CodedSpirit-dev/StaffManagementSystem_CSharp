using StaffTemplate.Shared.Services;
using Microsoft.EntityFrameworkCore;
using StaffManagementSystem.Server.Models;
using StaffTemplate.Server.Data;

namespace StaffTemplate.server.Services
{
    /// <summary>
    /// Represents a service for managing employees.
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeService"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all employees asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the list of employees.</returns>
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        /// <summary>
        /// Inserts a new employee asynchronously.
        /// </summary>
        /// <param name="employee">The employee to insert.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the inserted employee.</returns>
        public async Task<Employee> InsertEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        /// <summary>
        /// Retrieves an employee by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the retrieved employee.</returns>
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }
    }
}

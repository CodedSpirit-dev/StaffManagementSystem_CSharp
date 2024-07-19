using StaffManagementSystem.Server.Models;

namespace StaffTemplate.Shared.Services
{
    /// <summary>
    /// Represents an interface for managing employees.
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Retrieves a list of all employees.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the list of employees.</returns>
        Task<List<Employee>> GetEmployeesAsync();

        /// <summary>
        /// Inserts a new employee.
        /// </summary>
        /// <param name="employee">The employee to insert.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the inserted employee.</returns>
        Task<Employee> InsertEmployeeAsync(Employee employee);

        /// <summary>
        /// Retrieves an employee by their ID.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the retrieved employee.</returns>
        Task<Employee> GetEmployeeByIdAsync(int id);
    }
}

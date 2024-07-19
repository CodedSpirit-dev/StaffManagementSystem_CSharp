using StaffManagementSystem.Server.Models;

public interface IEmployeeRepository
{
    /// <summary>
    /// Creates a new employee asynchronously.
    /// </summary>
    /// <param name="employee">The employee to create.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task CreateEmployeeAsync(Employee employee);

    /// <summary>
    /// Retrieves all employees asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation that returns a collection of employees.</returns>
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
}

using StaffManagementSystem.Server.Models;

public interface IEmployeeRepository
{
    Task CreateEmployeeAsync(Employee employee);
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
}

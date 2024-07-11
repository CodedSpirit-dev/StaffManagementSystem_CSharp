using StaffTemplate.server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IEmployeeRepository
{
    Task CreateEmployeeAsync(Employee employee);
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
}

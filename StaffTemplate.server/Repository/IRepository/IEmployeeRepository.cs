using StaffTemplate.server.Models;
using System.Collections.Generic;

namespace StaffTemplate.server.Repository.IRepository
{
    public interface IEmployeeRepository
    {
        ICollection<Employee> GetEmployees();
        Employee GetEmployee(int id);
        bool EmployeeExists(string name);
        bool EmployeeExists(int id);
        bool CreateEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(Employee employee);
        bool DeleteEmployee(int id);
        bool Save();
    }
}

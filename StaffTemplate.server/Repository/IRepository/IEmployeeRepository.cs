using StaffTemplate.server.Models;
using System.Collections.Generic;

namespace StaffTemplate.server.Repository.IRepository
{
    public interface IEmployeeRepository
    {
        ICollection<Employee> GetEmployees();
        Employee GetEmployeeById(int id);
        Employee GetEmployeeBySocialSecurityNumber(int SocialSecurityNumber);
        bool EmployeeExists(string name);
        bool EmployeeExists(int SocialSecurityNumber);
        bool CreateEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(Employee employee);
        bool DeleteEmployee(int id);
        bool Save();
    }
}

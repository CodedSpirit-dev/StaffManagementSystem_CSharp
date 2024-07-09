using StaffTemplate.server.Models;

namespace StaffTemplate.server.Repository.IRepository
{
    public interface IEmployeeRepository
    {
        ICollection<Employee> GetEmployees();
        IEmployeeRepository GetEmployee(int id);
        bool EmployeeExists(String name);
        bool EmployeeExists(int id);
        bool CreateEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(Employee employee);
        bool DeleteEmployee(int id);
        bool Save();

    }
}

using StaffTemplate.server.Data;
using StaffTemplate.server.Models;
using StaffTemplate.server.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace StaffTemplate.server.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateEmployee(Employee employee)
        {
            _db.Add(employee);
            return Save();
        }

        public bool DeleteEmployee(int id)
        {
            // Retrieve the employee by their id
            var employee = _db.Employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                // Change IsActive to false
                employee.IsActive = false;
                // Update the employee record in the database
                _db.Employees.Update(employee);
                return Save();
            }
            return false;
        }

        public bool DeleteEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool EmployeeExists(string name)
        {
            bool value = _db.Employees.Any(a => a.FirstName.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool EmployeeExists(int SocialSecurityNumber)
        {
            return _db.Employees.Any(a => a.SocialSecurityNumber == SocialSecurityNumber);
        }

        public Employee GetEmployeeById(int id)
        {
            return _db.Employees.FirstOrDefault(e => e.Id == id);
        }

        public Employee GetEmployeeBySocialSecurityNumber(int SocialSecurityNumber)
        {
            return _db.Employees.FirstOrDefault(e => e.SocialSecurityNumber == SocialSecurityNumber);
        }

        public ICollection<Employee> GetEmployees()
        {
            return _db.Employees.OrderBy(a => a.FirstName).ToList();
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool UpdateEmployee(Employee employee)
        {
            _db.Employees.Update(employee);
            return Save();
        }
    }
}

using StaffTemplate.server.Models;
using System.Collections.Generic;

namespace StaffTemplate.server.Repository.IRepository
{
    public interface IEmployeeRepository
    {
        ICollection<Employee> GetEmployees();
        public bool CreateEmployee(Employee employee, Address address, EmergencyContact emergencyContact, ContactInfo contactInfo, EmploymentDetails employmentDetails);
    }
}

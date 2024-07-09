using StaffTemplate.server.Models.DTOs;

namespace StaffTemplate.server.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployees();
        Task<EmployeeDTO> GetEmployee(int id);
        Task<EmployeeDTO> CreateEmployee(EmployeeDTO employee);
        Task<EmployeeDTO> UpdateEmployee(int id, EmployeeDTO employee);
        Task<EmployeeDTO> DeleteEmployee(int id);
    }
}

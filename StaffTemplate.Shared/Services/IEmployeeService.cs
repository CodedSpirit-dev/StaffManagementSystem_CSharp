namespace StaffTemplate.Shared.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployeesAsync();
        Task<Employee> InsertEmployeeAsync(Employee employee);
        Task<Employee> GetEmployeeByIdAsync(int id);
    }
}

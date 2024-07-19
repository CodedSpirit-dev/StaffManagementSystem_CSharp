using Microsoft.EntityFrameworkCore;
using StaffManagementSystem.Server.Models;
using StaffTemplate.Server.Data;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _context;

    public EmployeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateEmployeeAsync(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await _context.Employees
                             .Include(e => e.Address)
                             .Include(e => e.ContactInfo)
                             .Include(e => e.EmergencyContact)
                             .Include(e => e.EmploymentDetails)
                             .ToListAsync();
    }
}

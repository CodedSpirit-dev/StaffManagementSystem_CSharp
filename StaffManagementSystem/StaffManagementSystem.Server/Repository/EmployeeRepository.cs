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

    /// <summary>
    /// Creates a new employee asynchronously.
    /// </summary>
    /// <param name="employee">The employee to create.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task CreateEmployeeAsync(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Retrieves all employees asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The task result contains the list of employees.</returns>
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

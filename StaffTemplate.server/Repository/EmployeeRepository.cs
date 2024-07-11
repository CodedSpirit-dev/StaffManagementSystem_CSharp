using StaffTemplate.server.Data;
using StaffTemplate.server.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

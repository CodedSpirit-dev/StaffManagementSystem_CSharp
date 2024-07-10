using StaffTemplate.server.Data;
using StaffTemplate.server.Models;

public class EmployeeService
{
    private readonly ApplicationDbContext _context;

    public EmployeeService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task InsertEmployeeAsync(Employee employee)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                // Inserta el empleado
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();

                // Inserta la información de contacto
                employee.ContactInfo.SocialSecurityNumber = employee.SocialSecurityNumber;
                _context.ContactInfos.Add(employee.ContactInfo);

                // Inserta la dirección
                employee.Address.SocialSecurityNumber = employee.SocialSecurityNumber;
                _context.Addresses.Add(employee.Address);

                // Inserta los detalles de empleo
                employee.EmploymentDetails.SocialSecurityNumber = employee.SocialSecurityNumber;
                _context.EmploymentDetails.Add(employee.EmploymentDetails);

                // Inserta el contacto de emergencia
                employee.EmergencyContact.SocialSecurityNumber = employee.SocialSecurityNumber;
                _context.EmergencyContacts.Add(employee.EmergencyContact);

                await _context.SaveChangesAsync();

                // Confirma la transacción
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                // Si hay un error, revierte la transacción
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}

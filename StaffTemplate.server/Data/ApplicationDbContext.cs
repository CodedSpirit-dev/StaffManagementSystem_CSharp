using Microsoft.EntityFrameworkCore;
using StaffTemplate.server.Models;

namespace StaffTemplate.server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }
        public DbSet<EmploymentDetails> EmploymentDetails { get; set; }
    }
}

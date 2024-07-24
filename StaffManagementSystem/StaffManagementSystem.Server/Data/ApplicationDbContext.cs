using Microsoft.EntityFrameworkCore;
using StaffManagementSystem.Server.Models;

namespace StaffTemplate.Server.Data
{
    /// <summary>
    /// Represents the application database context.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The options for configuring the context.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the employees DbSet.
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure owned types
            modelBuilder.Entity<Employee>()
                .OwnsOne(e => e.Address, address =>
                {
                    address.Property(a => a.Street).IsRequired().HasMaxLength(200);
                    address.Property(a => a.PostalCode).IsRequired().HasMaxLength(10);
                    address.Property(a => a.Neighborhood).IsRequired().HasMaxLength(100);
                    address.Property(a => a.City).IsRequired().HasMaxLength(100);
                    address.Property(a => a.State).IsRequired().HasMaxLength(100);
                });

            modelBuilder.Entity<Employee>()
                .OwnsOne(e => e.ContactInfo, contact =>
                {
                    contact.Property(c => c.Email).IsRequired().HasMaxLength(100);
                    contact.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(15);
                });

            modelBuilder.Entity<Employee>()
                .OwnsOne(e => e.EmploymentDetails, employment =>
                {
                    employment.Property(ed => ed.HiringDate).IsRequired();
                    employment.Property(ed => ed.Department).IsRequired().HasMaxLength(100);
                    employment.Property(ed => ed.Position).IsRequired().HasMaxLength(100);
                    employment.Property(ed => ed.BossName).IsRequired().HasMaxLength(100);
                    employment.Property(ed => ed.Shift).IsRequired().HasMaxLength(50);
                    employment.Property(ed => ed.HiredBy).IsRequired().HasMaxLength(100);
                    employment.Property(ed => ed.IsActive).IsRequired();
                    employment.Property(ed => ed.IsFileComplete).IsRequired();
                    employment.Property(ed => ed.Notes).HasMaxLength(500);
                });

            modelBuilder.Entity<Employee>()
                .OwnsOne(e => e.EmergencyContact, emergency =>
                {
                    emergency.Property(ec => ec.EmergencyContactName).IsRequired().HasMaxLength(100);
                    emergency.Property(ec => ec.EmergencyPhone).IsRequired().HasMaxLength(15);
                    emergency.Property(ec => ec.EmergencyRelationship).IsRequired().HasMaxLength(50);
                });
        }
    }
}
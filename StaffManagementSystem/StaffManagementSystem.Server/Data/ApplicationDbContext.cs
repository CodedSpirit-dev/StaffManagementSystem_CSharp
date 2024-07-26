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
                    address.Property(a => a.Street).HasMaxLength(200);
                    address.Property(a => a.Number).HasMaxLength(10);
                    address.Property(a => a.PostalCode).HasMaxLength(10);
                    address.Property(a => a.Neighborhood).HasMaxLength(100);
                    address.Property(a => a.City).HasMaxLength(100);
                    address.Property(a => a.State).HasMaxLength(100);
                });

            modelBuilder.Entity<Employee>()
                .OwnsOne(e => e.ContactInfo, contact =>
                {
                    contact.Property(c => c.Email).HasMaxLength(100);
                    contact.Property(c => c.PhoneNumber).HasMaxLength(20); // Ajustado a 20 caracteres
                });

            modelBuilder.Entity<Employee>()
                .OwnsOne(e => e.EmploymentDetails, employment =>
                {
                    employment.Property(ed => ed.HiringDate); // Asegúrate de que el tipo coincide con tu modelo
                    employment.Property(ed => ed.Department).HasMaxLength(100);
                    employment.Property(ed => ed.Position).HasMaxLength(100);
                    employment.Property(ed => ed.BossName).HasMaxLength(100);
                    employment.Property(ed => ed.Shift).HasMaxLength(50);
                    employment.Property(ed => ed.HiredBy).HasMaxLength(100);
                    employment.Property(ed => ed.IsActive);
                    employment.Property(ed => ed.IsFileComplete);
                    employment.Property(ed => ed.Notes).HasMaxLength(500);

                    // Propiedades adicionales
                    employment.Property(ed => ed.DateOfJoining); // Verificar tipo
                    employment.Property(ed => ed.ResignationDate).HasColumnType("date"); // O "timestamp" si se requiere la hora
                    employment.Property(ed => ed.InsuranceActive);
                    employment.Property(ed => ed.BirthCertificate);
                    employment.Property(ed => ed.NoCriminalRecordCertificate);
                    employment.Property(ed => ed.INE).HasMaxLength(18);
                    employment.Property(ed => ed.RegistrationDate).HasColumnType("date"); // O "timestamp"
                    employment.Property(ed => ed.Salary).HasColumnType("decimal(18,2)");
                    employment.Property(ed => ed.BankName).HasMaxLength(100);
                    employment.Property(ed => ed.InterbankClabe).HasMaxLength(18);
                    employment.Property(ed => ed.PaymentFrequency).HasMaxLength(50);
                    employment.Property(ed => ed.PayrollType).HasMaxLength(50);
                });

            modelBuilder.Entity<Employee>()
                .OwnsOne(e => e.EmergencyContact, emergency =>
                {
                    emergency.Property(ec => ec.EmergencyContactName).HasMaxLength(100);
                    emergency.Property(ec => ec.EmergencyPhone).HasMaxLength(20); // Ajustado a 20 caracteres
                    emergency.Property(ec => ec.EmergencyRelationship).HasMaxLength(50); // Ajustar según modelo
                });
        }
    }
}

namespace StaffManagementSystem.Server.Models.DTOs
{
    /// <summary>
    /// Represents an employee data transfer object.
    /// </summary>
    public class EmployeeDTO
    {
        /// <summary>
        /// Gets or sets the social security number of the employee.
        /// </summary>
        public int SocialSecurityNumber { get; set; }

        /// <summary>
        /// Gets or sets the RFC (Registro Federal de Contribuyentes) of the employee.
        /// </summary>
        public string RFC { get; set; }

        /// <summary>
        /// Gets or sets the CURP (Clave Única de Registro de Población) of the employee.
        /// </summary>
        public string CURP { get; set; }

        /// <summary>
        /// Gets or sets the first name of the employee.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the middle name of the employee.
        /// </summary>
        public string? MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the employee.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the second last name of the employee.
        /// </summary>
        public string? SecondLastname { get; set; }

        /// <summary>
        /// Gets or sets the birth date of the employee.
        /// </summary>
        public DateOnly BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the gender of the employee.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the blood type of the employee.
        /// </summary>
        public string BloodType { get; set; }

        /// <summary>
        /// Gets or sets the marital status of the employee.
        /// </summary>
        public string MaritalStatus { get; set; }

        /// <summary>
        /// Gets or sets the number of children of the employee.
        /// </summary>
        public int Children { get; set; }

        /// <summary>
        /// Gets or sets the contact information of the employee.
        /// </summary>
        public ContactInfoDTO ContactInfo { get; set; }

        /// <summary>
        /// Gets or sets the address of the employee.
        /// </summary>
        public AddressDTO Address { get; set; }

        /// <summary>
        /// Gets or sets the employment details of the employee.
        /// </summary>
        public EmploymentDetailsDTO EmploymentDetails { get; set; }

        /// <summary>
        /// Gets or sets the emergency contact information of the employee.
        /// </summary>
        public EmergencyContactDTO EmergencyContact { get; set; }
    }

    /// <summary>
    /// Represents an address data transfer object.
    /// </summary>
    public class AddressDTO
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }

    /// <summary>
    /// Represents a contact information data transfer object.
    /// </summary>
    public class ContactInfoDTO
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    /// <summary>
    /// Represents an employment details data transfer object.
    /// </summary>
    public class EmploymentDetailsDTO
    {
        public string Position { get; set; }
        public string Department { get; set; }
        public DateOnly DateOfJoining { get; set; }
        public DateTime HiringDate { get; set; }
        public DateTime? ResignationDate { get; set; }
        public string BossName { get; set; }
        public string Shift { get; set; }
        public string HiredBy { get; set; }
        public string? StudyGrade { get; set; }
        public decimal Salary { get; set; }
        public string? BankName { get; set; }
        public string? InterbankClabe { get; set; }
        public string? PaymentFrequency { get; set; }
        public string? PayrollType { get; set; }
        public bool IsActive { get; set; }
        public bool InsuranceActive { get; set; }
        public bool IsFileComplete { get; set; }
        public bool BirthCertificate { get; set; }
        public bool NoCriminalRecordCertificate { get; set; }
        public bool? INE { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string Notes { get; set; }
    }

    /// <summary>
    /// Represents an emergency contact data transfer object.
    /// </summary>
    public class EmergencyContactDTO
    {
        public string EmergencyContactName { get; set; }
        public string EmergencyPhone { get; set; }
        public string? EmergencyRelationship { get; set; }
    }
}

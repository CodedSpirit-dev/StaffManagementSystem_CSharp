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
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the employee.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the second last name of the employee.
        /// </summary>
        public string SecondLastname { get; set; }

        /// <summary>
        /// Gets or sets the birth date of the employee.
        /// </summary>
        public DateOnly BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the gender of the employee.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the marital status of the employee.
        /// </summary>
        public string MaritalStatus { get; set; }

        /// <summary>
        /// Gets or sets the number of children of the employee.
        /// </summary>
        public int Children { get; set; }

        /// <summary>
        /// Gets or sets the study grade of the employee.
        /// </summary>
        public string StudyGrade { get; set; }

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
        /// <summary>
        /// Gets or sets the address line of the address.
        /// </summary>
        public string AddressLine { get; set; }

        /// <summary>
        /// Gets or sets the postal code of the address.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the neighborhood of the address.
        /// </summary>
        public string Neighborhood { get; set; }

        /// <summary>
        /// Gets or sets the city of the address.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state of the address.
        /// </summary>
        public string State { get; set; }
    }

    /// <summary>
    /// Represents a contact information data transfer object.
    /// </summary>
    public class ContactInfoDTO
    {
        /// <summary>
        /// Gets or sets the email of the contact information.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the contact information.
        /// </summary>
        public string PhoneNumber { get; set; }
    }

    /// <summary>
    /// Represents an employment details data transfer object.
    /// </summary>
    public class EmploymentDetailsDTO
    {
        /// <summary>
        /// Gets or sets the hiring date of the employment details.
        /// </summary>
        public DateTime HiringDate { get; set; }

        /// <summary>
        /// Gets or sets the department of the employment details.
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Gets or sets the position of the employment details.
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Gets or sets the boss name of the employment details.
        /// </summary>
        public string BossName { get; set; }

        /// <summary>
        /// Gets or sets the shift of the employment details.
        /// </summary>
        public string Shift { get; set; }

        /// <summary>
        /// Gets or sets the name of the person who hired the employee.
        /// </summary>
        public string HiredBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the employee is active or not.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the employee's file is complete or not.
        /// </summary>
        public bool IsFileComplete { get; set; }

        /// <summary>
        /// Gets or sets the notes for the employment details.
        /// </summary>
        public string Notes { get; set; }
    }

    /// <summary>
    /// Represents an emergency contact data transfer object.
    /// </summary>
    public class EmergencyContactDTO
    {
        /// <summary>
        /// Gets or sets the name of the emergency contact.
        /// </summary>
        public string EmergencyContactName { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the emergency contact.
        /// </summary>
        public string EmergencyPhone { get; set; }

        /// <summary>
        /// Gets or sets the relationship of the emergency contact with the employee.
        /// </summary>
        public string EmergencyRelationship { get; set; }
    }
}
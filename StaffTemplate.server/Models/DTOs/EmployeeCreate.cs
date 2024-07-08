namespace StaffTemplate.server.Models.DTOs
{
    public class EmployeeCreateDTO
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Office { get; set; }
        public int Salary { get; set; }
        public EmployeeCreateDTO() { }
    }
}

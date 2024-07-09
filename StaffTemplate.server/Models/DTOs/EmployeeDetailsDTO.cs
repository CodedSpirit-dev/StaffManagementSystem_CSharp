namespace StaffTemplate.server.Models.DTOs
{
    public class EmploymentDetailsDTO
    {
        public DateTime HiringDate { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string BossName { get; set; }
        public string Shift { get; set; }
        public string HiredBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsFileComplete { get; set; }
        public string Notes { get; set; }
    }

}

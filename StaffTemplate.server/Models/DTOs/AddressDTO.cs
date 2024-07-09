namespace StaffTemplate.server.Models.DTOs
{
    public class AddressDTO
    {
        public int SocialSecurityNumber { get; set; }
        public string AddressLine { get; set; }
        public string PostalCode { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }

}

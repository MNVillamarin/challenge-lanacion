namespace LaNacion.Application.DTOs
{
    public class ContactDTO
    {
        public string Name { get; set; }
        public string? Company { get; set; }
        public string? ProfileImage { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public IEnumerable<PhoneDTO>? Phones { get; set; }
        public AddressDTO? Address { get; set; }
    }
}

namespace LaNacion.Application.DTOs.Contacts
{
    public class CreateContactDTO
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public string ProfileImage { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public IEnumerable<CreatePhoneDTO>? Phones { get; set; }
        public CreateAddressDTO? Address { get; set; }
    }
}

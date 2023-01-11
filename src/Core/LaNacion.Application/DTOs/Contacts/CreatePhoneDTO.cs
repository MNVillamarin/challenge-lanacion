using LaNacion.Domain.Enums;

namespace LaNacion.Application.DTOs.Contacts
{
    public class CreatePhoneDTO
    {
        public PhoneType PhoneType { get; set; }
        public string PhoneNumber { get; set; }
    }
}

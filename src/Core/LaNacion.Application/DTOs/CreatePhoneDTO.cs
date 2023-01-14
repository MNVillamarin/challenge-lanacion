using LaNacion.Domain.Enums;

namespace LaNacion.Application.DTOs
{
    public class CreatePhoneDTO
    {
        public PhoneType PhoneType { get; set; }
        public string PhoneNumber { get; set; }
    }
}

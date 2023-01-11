using LaNacion.Domain.Enums;

namespace LaNacion.Application.DTOs.Contacts
{
    public class PhoneDTO
    {
        public int Id { get; set; }
        public PhoneType PhoneType { get; set; }
        public string PhoneNumber { get; set; }
    }
}

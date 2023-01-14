using LaNacion.Domain.Enums;

namespace LaNacion.Application.DTOs
{
    public class PhoneDTO
    {
        public int Id { get; set; }
        public PhoneType PhoneType { get; set; }
        public string PhoneNumber { get; set; }
    }
}

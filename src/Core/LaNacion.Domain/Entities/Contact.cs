using LaNacion.Domain.Common;

namespace LaNacion.Domain.Entities
{
    public class Contact : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string? Company { get; set; }
        public string? ProfileImage { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public IEnumerable<Phone>? Phones { get; set; }
        public Address? Address { get; set; }

    }
}

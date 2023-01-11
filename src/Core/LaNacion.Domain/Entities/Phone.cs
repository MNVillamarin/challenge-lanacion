using LaNacion.Domain.Common;
using LaNacion.Domain.Enums;

namespace LaNacion.Domain.Entities
{
    public class Phone : AuditableBaseEntity
    {
        public PhoneType PhoneType { get; set; }
        public string PhoneNumber { get; set; }

        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}

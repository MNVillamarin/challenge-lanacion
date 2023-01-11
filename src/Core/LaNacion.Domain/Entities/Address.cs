using LaNacion.Domain.Common;

namespace LaNacion.Domain.Entities
{
    public class Address : AuditableBaseEntity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}

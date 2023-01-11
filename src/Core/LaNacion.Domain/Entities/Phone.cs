using LaNacion.Domain.Common;

namespace LaNacion.Domain.Entities
{
    public enum PhoneType { Work, Personal }
    public class Phone : AuditableBaseEntity
    {
        public PhoneType PhoneType { get; set; }
        public string PhoneNumber { get; set; }

    }
}

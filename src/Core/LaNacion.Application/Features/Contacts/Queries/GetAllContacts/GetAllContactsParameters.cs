using LaNacion.Application.Parameters;

namespace LaNacion.Application.Features.Contacts.Queries.GetAllContacts
{
    public class GetAllContactsParameters : PagedResponseParameters
    {
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
    }
}

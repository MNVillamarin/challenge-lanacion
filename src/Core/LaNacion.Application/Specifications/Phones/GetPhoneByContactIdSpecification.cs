using Ardalis.Specification;
using LaNacion.Domain.Entities;

namespace LaNacion.Application.Specifications.Phones
{
    public class GetPhoneByContactIdSpecification : Specification<Phone>, ISingleResultSpecification
    {
        public GetPhoneByContactIdSpecification(int contactId)
        {
            Query
                .Where(x => x.ContactId == contactId);
        }
    }
}

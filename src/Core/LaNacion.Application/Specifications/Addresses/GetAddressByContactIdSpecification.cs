using Ardalis.Specification;
using LaNacion.Domain.Entities;

namespace LaNacion.Application.Specifications.Addresses
{
    public class GetAddressByContactIdSpecification : Specification<Address>, ISingleResultSpecification
    {
        public GetAddressByContactIdSpecification(int contactId)
        {
            Query
                .Where(x => x.ContactId == contactId);
        }
    }
}

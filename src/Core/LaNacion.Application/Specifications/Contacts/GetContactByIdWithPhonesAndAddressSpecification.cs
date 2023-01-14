using Ardalis.Specification;
using LaNacion.Domain.Entities;

namespace LaNacion.Application.Specifications.Contacts
{
    public class GetContactByIdWithPhonesAndAddressSpecification : Specification<Contact>, ISingleResultSpecification
    {
        public GetContactByIdWithPhonesAndAddressSpecification(int id)
        {
            Query
                .Where(x => x.Id == id)
                .Include(x => x.Phones)
                .Include(x => x.Address);
        }
    }
}

using Ardalis.Specification;
using LaNacion.Domain.Entities;

namespace LaNacion.Application.Specifications.Contacts
{
    public class GetContactsByParametersPaged : Specification<Contact>
    {
        public GetContactsByParametersPaged(int pageSize, int pageNumber, string? email = null, string? phoneNumber = null, string? city = null, string? state = null)
        {
            //Paged
            Query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            //Include
            Query
                .Include(x => x.Phones)
                .Include(x => x.Address);

            //Where
            if (!string.IsNullOrEmpty(email))
            {
                Query
                    .Where(x => x.Email.ToUpper().Contains(email.ToUpper()));
            }

            if (!string.IsNullOrEmpty(city))
            {
                Query
                    .Where(x => x.Address.City.ToUpper().Contains(city.ToUpper()));
            }

            if (!string.IsNullOrEmpty(state))
            {
                Query
                    .Where(x => x.Address.State.ToUpper().Contains(state.ToUpper()));
            }

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                Query
                    .Where(x => x.Phones.Any(p => p.PhoneNumber.Contains(phoneNumber)));
            }

        }

    }
}

using AutoMapper;
using LaNacion.Application.DTOs;
using LaNacion.Application.Interfaces;
using LaNacion.Application.Specifications.Contacts;
using LaNacion.Application.Wrappers;
using LaNacion.Domain.Entities;
using MediatR;

namespace LaNacion.Application.Features.Contacts.Queries.GetContactsByParameters
{
    public class GetAllContactsQuery : IRequest<PagedResponse<List<ContactDTO>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
    }

    public class GetAllContactsHandler : IRequestHandler<GetAllContactsQuery, PagedResponse<List<ContactDTO>>>
    {
        private readonly IRepositoryAsync<Contact> _repositoryContactsAsync;
        private readonly IRepositoryAsync<Phone> _repositoryPhonesAsync;
        private readonly IMapper _mapper;

        public GetAllContactsHandler(IRepositoryAsync<Contact> repositoryContactsAsync, IRepositoryAsync<Phone> repositoryPhonesAsync,
            IRepositoryAsync<Address> repositoryAddressesAsync, IMapper mapper)
        {
            _repositoryContactsAsync = repositoryContactsAsync;
            _repositoryPhonesAsync = repositoryPhonesAsync;
            _mapper = mapper;
        }

        public async Task<PagedResponse<List<ContactDTO>>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            List<Contact> contactList = new List<Contact>();

            contactList = await _repositoryContactsAsync.ListAsync(new GetContactsByParametersPaged(
                request.PageSize,
                request.PageNumber,
                request.Email,
                request.PhoneNumber,
                request.City,
                request.State));

            var clientesDto = _mapper.Map<List<ContactDTO>>(contactList);

            var totalCount = clientesDto.Count;
            var pageCount = (totalCount / request.PageSize) + 1;

            return new PagedResponse<List<ContactDTO>>(clientesDto, request.PageNumber, totalCount, request.PageSize, pageCount);
        }
    }
}

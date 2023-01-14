using Application.Wrappers;
using AutoMapper;
using LaNacion.Application.DTOs;
using LaNacion.Application.Interfaces;
using LaNacion.Application.Specifications.Contacts;
using LaNacion.Domain.Entities;
using MediatR;

namespace LaNacion.Application.Features.Contacts.Queries.GetContactById
{
    public class GetContactByIdQuery : IRequest<Response<ContactDTO>>
    {
        public int Id { get; set; }

    }

    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, Response<ContactDTO>>
    {
        private readonly IRepositoryAsync<Contact> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetContactByIdQueryHandler(IRepositoryAsync<Contact> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<ContactDTO>> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var specs = new GetContactByIdWithPhonesAndAddressSpecification(request.Id);
            var contact = await _repositoryAsync.FirstOrDefaultAsync(specs, cancellationToken);

            if (contact == null)
                throw new KeyNotFoundException($"Contact not found with id: {request.Id}.");

            var contactDto = _mapper.Map<ContactDTO>(contact);
            return new Response<ContactDTO>(contactDto);
        }
    }
}

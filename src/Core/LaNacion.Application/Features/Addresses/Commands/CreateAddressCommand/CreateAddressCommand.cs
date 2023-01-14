using Application.Wrappers;
using AutoMapper;
using LaNacion.Application.Interfaces;
using LaNacion.Domain.Entities;
using MediatR;

namespace LaNacion.Application.Features.Addresses.Commands.CreateAddressCommand
{
    public class CreateAddressCommand : IRequest<Response<int>>
    {
        public int ContactId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }

    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, Response<int>>
    {

        private readonly IRepositoryAsync<Address> _repositoryAddressAsync;
        private readonly IRepositoryAsync<Contact> _repositoryContactAsync;
        private readonly IMapper _mapper;

        public CreateAddressCommandHandler(IRepositoryAsync<Address> repositoryAddressAsync, IRepositoryAsync<Contact> repositoryContactAsync, IMapper mapper)
        {
            _repositoryAddressAsync = repositoryAddressAsync;
            _repositoryContactAsync = repositoryContactAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var existContact = await _repositoryContactAsync.GetByIdAsync(request.ContactId);
            if (existContact == null)
            {
                throw new KeyNotFoundException("Contact Id not found.");
            }

            var newRecord = _mapper.Map<Address>(request);
            var data = await _repositoryAddressAsync.AddAsync(newRecord);

            return new Response<int>(data.Id);
        }
    }
}

using Application.Wrappers;
using AutoMapper;
using LaNacion.Application.DTOs;
using LaNacion.Application.Interfaces;
using LaNacion.Application.Specifications.Addresses;
using LaNacion.Domain.Entities;
using MediatR;

namespace LaNacion.Application.Features.Addresses.Queries.GetAddressByContactId
{
    public class GetAddressByContactIdQuery : IRequest<Response<AddressDTO>>
    {
        public int ContactId { get; set; }
    }

    public class GetAddressByContactIdQueryHandler : IRequestHandler<GetAddressByContactIdQuery, Response<AddressDTO>>
    {
        private readonly IRepositoryAsync<Address> _repositoryAddressAsync;
        private readonly IMapper _mapper;

        public GetAddressByContactIdQueryHandler(IRepositoryAsync<Address> repositoryAddressAsync, IMapper mapper)
        {
            _repositoryAddressAsync = repositoryAddressAsync;
            _mapper = mapper;
        }

        public async Task<Response<AddressDTO>> Handle(GetAddressByContactIdQuery request, CancellationToken cancellationToken)
        {

            var address = await _repositoryAddressAsync.FirstOrDefaultAsync(new GetAddressByContactIdSpecification(request.ContactId), cancellationToken);

            if (address == null)
            {
                throw new KeyNotFoundException($"Address not found with ContactId: {request.ContactId}.");
            }

            var addressDTO = _mapper.Map<AddressDTO>(address);
            return new Response<AddressDTO>(addressDTO);

        }
    }
}


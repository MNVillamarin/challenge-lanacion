using Application.Wrappers;
using AutoMapper;
using LaNacion.Application.DTOs;
using LaNacion.Application.Interfaces;
using LaNacion.Domain.Entities;
using MediatR;

namespace LaNacion.Application.Features.Addresses.Queries.GetAddressById
{
    public class GetAddressByIdQuery : IRequest<Response<AddressDTO>>
    {
        public int Id { get; set; }
    }

    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, Response<AddressDTO>>
    {
        private readonly IRepositoryAsync<Address> _repositoryAddressAsync;
        private readonly IMapper _mapper;

        public GetAddressByIdQueryHandler(IRepositoryAsync<Address> repositoryAddressAsync, IMapper mapper)
        {
            _repositoryAddressAsync = repositoryAddressAsync;
            _mapper = mapper;
        }

        public async Task<Response<AddressDTO>> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var address = await _repositoryAddressAsync.GetByIdAsync(request.Id);

            if (address == null)
                throw new KeyNotFoundException($"Address not found with id: {request.Id}.");

            var addressDto = _mapper.Map<AddressDTO>(address);
            return new Response<AddressDTO>(addressDto);
        }
    }
}

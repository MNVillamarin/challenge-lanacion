using Application.Wrappers;
using AutoMapper;
using LaNacion.Application.Interfaces;
using LaNacion.Domain.Entities;
using MediatR;

namespace LaNacion.Application.Features.Addresses.Commands.UpdateAddressCommand
{
    public class UpdateAddressCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }

    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Address> _repositoryAddressAsync;
        private readonly IMapper _mapper;

        public UpdateAddressCommandHandler(IRepositoryAsync<Address> repositoryAddressAsync, IMapper mapper)
        {
            _repositoryAddressAsync = repositoryAddressAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _repositoryAddressAsync.GetByIdAsync(request.Id);

            if (address == null)
                throw new KeyNotFoundException($"Address not found with id: {request.Id}.");

            address = _mapper.Map(request, address);
            await _repositoryAddressAsync.UpdateAsync(address);
            await _repositoryAddressAsync.SaveChangesAsync();
            return new Response<int>(address.Id);
        }
    }

}

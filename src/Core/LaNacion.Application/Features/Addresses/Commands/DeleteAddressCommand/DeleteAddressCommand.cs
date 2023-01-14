using Application.Wrappers;
using LaNacion.Application.Interfaces;
using LaNacion.Domain.Entities;
using MediatR;

namespace LaNacion.Application.Features.Addresses.Commands.DeleteAddressCommand
{
    public class DeleteAddressCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Address> _repositoryAddressAsync;

        public DeleteAddressCommandHandler(IRepositoryAsync<Address> repositoryAddressAsync)
        {
            _repositoryAddressAsync = repositoryAddressAsync;
        }

        public async Task<Response<int>> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _repositoryAddressAsync.GetByIdAsync(request.Id);

            if (address == null)
                throw new KeyNotFoundException($"Address not found with id: {request.Id}.");

            await _repositoryAddressAsync.DeleteAsync(address);

            return new Response<int>(address.Id);
        }
    }
}

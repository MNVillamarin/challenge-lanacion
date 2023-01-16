using Application.Wrappers;
using LaNacion.Application.Interfaces;
using LaNacion.Domain.Entities;
using MediatR;

namespace LaNacion.Application.Features.Phones.Commands.DeletePhoneCommand
{
    public class DeletePhoneCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeletePhoneCommandHandler : IRequestHandler<DeletePhoneCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Phone> _repositoryPhoneAsync;

        public DeletePhoneCommandHandler(IRepositoryAsync<Phone> repositoryPhoneAsync)
        {
            _repositoryPhoneAsync = repositoryPhoneAsync;
        }

        public async Task<Response<int>> Handle(DeletePhoneCommand request, CancellationToken cancellationToken)
        {
            var phone = await _repositoryPhoneAsync.GetByIdAsync(request.Id);

            if (phone == null)
                throw new KeyNotFoundException($"Phone not found with id: {request.Id}.");

            await _repositoryPhoneAsync.DeleteAsync(phone);
            await _repositoryPhoneAsync.SaveChangesAsync();
            return new Response<int>(phone.Id);
        }
    }
}

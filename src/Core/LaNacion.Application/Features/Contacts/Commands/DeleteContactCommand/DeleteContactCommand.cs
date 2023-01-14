using Application.Wrappers;
using LaNacion.Application.Interfaces;
using LaNacion.Domain.Entities;
using MediatR;

namespace LaNacion.Application.Features.Contacts.Commands.DeleteContactCommand
{
    public class DeleteContactCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteContactHandler : IRequestHandler<DeleteContactCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Contact> _repositoryAsync;

        public DeleteContactHandler(IRepositoryAsync<Contact> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _repositoryAsync.GetByIdAsync(request.Id);

            if (contact == null)
                throw new KeyNotFoundException($"Contact not found with id: {request.Id}.");

            await _repositoryAsync.DeleteAsync(contact);

            return new Response<int>(contact.Id);
        }
    }
}

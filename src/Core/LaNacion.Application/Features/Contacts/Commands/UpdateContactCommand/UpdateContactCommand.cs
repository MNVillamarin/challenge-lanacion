using Application.Wrappers;
using AutoMapper;
using LaNacion.Application.Interfaces;
using LaNacion.Domain.Entities;
using MediatR;

namespace LaNacion.Application.Features.Contacts.Commands.UpdateContactCommand
{
    public class UpdateContactCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string ProfileImage { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
    }

    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Contact> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateContactCommandHandler(IRepositoryAsync<Contact> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _repositoryAsync.GetByIdAsync(request.Id);

            if (contact == null)
                throw new KeyNotFoundException($"Contact not found with id: {request.Id}.");

            contact = _mapper.Map(request, contact);
            await _repositoryAsync.UpdateAsync(contact);
            await _repositoryAsync.SaveChangesAsync();
            return new Response<int>(contact.Id);
        }
    }
}

using Application.Wrappers;
using AutoMapper;
using LaNacion.Application.DTOs.Contacts;
using LaNacion.Application.Interfaces;
using LaNacion.Domain.Entities;
using MediatR;

namespace LaNacion.Application.Features.Contacts.Commands.CreateContactCommand
{
    public class CreateContactCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public string ProfileImage { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public IEnumerable<CreatePhoneDTO>? Phones { get; set; } = null;
        public CreateAddressDTO? Address { get; set; } = null;
    }

    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Contact> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateContactCommandHandler(IRepositoryAsync<Contact> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }


        public async Task<Response<int>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var newRecord = _mapper.Map<Contact>(request);
            var data = await _repositoryAsync.AddAsync(newRecord);

            return new Response<int>(data.Id);
        }
    }
}

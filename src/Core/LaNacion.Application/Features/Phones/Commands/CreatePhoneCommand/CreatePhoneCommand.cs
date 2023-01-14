using Application.Wrappers;
using AutoMapper;
using LaNacion.Application.Interfaces;
using LaNacion.Domain.Entities;
using LaNacion.Domain.Enums;
using MediatR;

namespace LaNacion.Application.Features.Phones.Commands.CreatePhoneCommand
{
    public class CreatePhoneCommand : IRequest<Response<int>>
    {
        public int ContactId { get; set; }
        public PhoneType PhoneType { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class CreatePhoneCommandHandler : IRequestHandler<CreatePhoneCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Phone> _repositoryPhoneAsync;
        private readonly IRepositoryAsync<Contact> _repositoryContactAsync;
        private readonly IMapper _mapper;

        public CreatePhoneCommandHandler(IRepositoryAsync<Phone> repositoryAsync, IMapper mapper, IRepositoryAsync<Contact> repositoryContactAsync)
        {
            _repositoryPhoneAsync = repositoryAsync;
            _mapper = mapper;
            _repositoryContactAsync = repositoryContactAsync;
        }

        public async Task<Response<int>> Handle(CreatePhoneCommand request, CancellationToken cancellationToken)
        {
            var existContact = await _repositoryContactAsync.GetByIdAsync(request.ContactId);
            if (existContact == null)
            {
                throw new KeyNotFoundException("Contact Id not found.");
            }

            var newRecord = _mapper.Map<Phone>(request);
            var data = await _repositoryPhoneAsync.AddAsync(newRecord);

            return new Response<int>(data.Id);
        }
    }
}

using Application.Wrappers;
using AutoMapper;
using LaNacion.Application.Interfaces;
using LaNacion.Domain.Entities;
using LaNacion.Domain.Enums;
using MediatR;

namespace LaNacion.Application.Features.Phones.Commands.UpdatePhoneCommand
{
    public class UpdatePhoneCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public PhoneType PhoneType { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class UpdatePhoneCommandHandler : IRequestHandler<UpdatePhoneCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Phone> _repositoryPhoneAsync;
        private readonly IMapper _mapper;

        public UpdatePhoneCommandHandler(IRepositoryAsync<Phone> repositoryPhoneAsync, IMapper mapper)
        {
            _repositoryPhoneAsync = repositoryPhoneAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdatePhoneCommand request, CancellationToken cancellationToken)
        {
            var phone = await _repositoryPhoneAsync.GetByIdAsync(request.Id);

            if (phone == null)
                throw new KeyNotFoundException($"Phone not found with id: {request.Id}.");

            phone = _mapper.Map(request, phone);
            await _repositoryPhoneAsync.UpdateAsync(phone);
            await _repositoryPhoneAsync.SaveChangesAsync();
            return new Response<int>(phone.Id);
        }

    }
}

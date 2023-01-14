using Application.Wrappers;
using AutoMapper;
using LaNacion.Application.DTOs;
using LaNacion.Application.Interfaces;
using LaNacion.Domain.Entities;
using MediatR;

namespace LaNacion.Application.Features.Phones.Queries.GetPhoneById
{
    public class GetPhoneByIdQuery : IRequest<Response<PhoneDTO>>
    {
        public int Id { get; set; }

    }

    public class GetPhoneByIdQueryHandler : IRequestHandler<GetPhoneByIdQuery, Response<PhoneDTO>>
    {
        private readonly IRepositoryAsync<Phone> _repositoryPhoneAsync;
        private readonly IMapper _mapper;

        public GetPhoneByIdQueryHandler(IRepositoryAsync<Phone> repositoryAsync, IMapper mapper)
        {
            _repositoryPhoneAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<PhoneDTO>> Handle(GetPhoneByIdQuery request, CancellationToken cancellationToken)
        {
            var phone = await _repositoryPhoneAsync.GetByIdAsync(request.Id);

            if (phone == null)
                throw new KeyNotFoundException($"Phone not found with id: {request.Id}.");

            var phoneDto = _mapper.Map<PhoneDTO>(phone);
            return new Response<PhoneDTO>(phoneDto);
        }
    }
}

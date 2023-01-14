using Application.Wrappers;
using AutoMapper;
using LaNacion.Application.DTOs;
using LaNacion.Application.Interfaces;
using LaNacion.Application.Specifications.Phones;
using LaNacion.Domain.Entities;
using MediatR;

namespace LaNacion.Application.Features.Phones.Queries.GetPhonesByContactId
{
    public class GetPhoneByContactIdQuery : IRequest<Response<PhoneDTO>>
    {
        public int ContactId { get; set; }

    }

    public class GetPhoneByContactIdQueryHandler : IRequestHandler<GetPhoneByContactIdQuery, Response<PhoneDTO>>
    {
        private readonly IRepositoryAsync<Phone> _repositoryPhoneAsync;
        private readonly IMapper _mapper;

        public GetPhoneByContactIdQueryHandler(IRepositoryAsync<Phone> repositoryAsync, IMapper mapper)
        {
            _repositoryPhoneAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<PhoneDTO>> Handle(GetPhoneByContactIdQuery request, CancellationToken cancellationToken)
        {
            var phone = await _repositoryPhoneAsync.FirstOrDefaultAsync(new GetPhoneByContactIdSpecification(request.ContactId), cancellationToken);

            if (phone == null)
                throw new KeyNotFoundException($"Phone not found with Contact Id: {request.ContactId}.");

            var phoneDto = _mapper.Map<PhoneDTO>(phone);
            return new Response<PhoneDTO>(phoneDto);
        }
    }
}

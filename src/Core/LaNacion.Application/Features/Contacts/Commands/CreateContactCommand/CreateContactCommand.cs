using Application.Wrappers;
using LaNacion.Application.DTOs.Contacts;
using MediatR;

namespace LaNacion.Application.Features.Contacts.Commands.CreateContactCommand
{
    public class CreateContactCommand : IRequest<Response<int>>
    {
        public CreateContactDTO CreateContactDTO { get; set; }
    }

    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Response<int>>
    {
        public Task<Response<int>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

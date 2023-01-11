using Application.Wrappers;
using MediatR;

namespace LaNacion.Application.Features.Contacts.Commands.DeleteContactCommand
{
    public class DeleteContactCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteContactHandler : IRequestHandler<DeleteContactCommand, Response<int>>
    {
        public Task<Response<int>> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

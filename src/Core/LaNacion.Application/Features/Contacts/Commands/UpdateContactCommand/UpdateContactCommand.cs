using Application.Wrappers;
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
        public IEnumerable<Phone>? Phones { get; set; }
        public Address? Address { get; set; }
    }
}

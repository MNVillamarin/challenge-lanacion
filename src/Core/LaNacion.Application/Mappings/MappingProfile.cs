using AutoMapper;
using LaNacion.Application.DTOs.Contacts;
using LaNacion.Application.Features.Contacts.Commands.CreateContactCommand;
using LaNacion.Domain.Entities;

namespace LaNacion.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Commands
            CreateMap<Contact, CreateContactCommand>().ReverseMap();
            CreateMap<Phone, CreatePhoneDTO>().ReverseMap();
            CreateMap<Address, CreateAddressDTO>().ReverseMap();
            #endregion
        }
    }
}

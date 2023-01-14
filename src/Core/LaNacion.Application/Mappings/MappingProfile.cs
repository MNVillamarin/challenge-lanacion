using AutoMapper;
using LaNacion.Application.DTOs;
using LaNacion.Application.Features.Contacts.Commands.CreateContactCommand;
using LaNacion.Application.Features.Contacts.Commands.UpdateContactCommand;
using LaNacion.Domain.Entities;

namespace LaNacion.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Commands
            CreateMap<Contact, CreateContactCommand>().ReverseMap();
            CreateMap<Contact, UpdateContactCommand>().ReverseMap();
            #endregion

            #region DTO's
            CreateMap<Phone, CreatePhoneDTO>().ReverseMap();
            CreateMap<Address, CreateAddressDTO>().ReverseMap();
            CreateMap<Phone, PhoneDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<Contact, ContactDTO>().ReverseMap();
            #endregion
        }
    }
}

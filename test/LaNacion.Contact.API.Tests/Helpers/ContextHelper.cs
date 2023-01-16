using AutoMapper;
using LaNacion.Application.Interfaces;
using LaNacion.Application.Mappings;
using LaNacion.Domain.Entities;
using LaNacion.Persistence.Contexts;
using LaNacion.Persistence.Repository;
using LaNacion.Persistence.Seed;
using LaNacion.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace LaNacion.Contacts.API.Tests.Helpers
{
    public class ContextHelper
    {
        private readonly ApplicationDbContext ApplicationDbContext;
        private readonly IDateTimeService dataTimeService;

        public ContextHelper()
        {
            dataTimeService = new DateTimeService();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseInMemoryDatabase(databaseName: "ContactsDbInMemory");

            var dbContextOptions = builder.Options;
            ApplicationDbContext = new ApplicationDbContext(dbContextOptions, dataTimeService);

            // Delete existing db before creating a new one
            ApplicationDbContext.Database.EnsureDeleted();
            ApplicationDbContext.Database.EnsureCreated();

            SeedData();
        }


        public IRepositoryAsync<Contact> GetInMemoryContactRepository()
        {
            return new ApplicationRepositoryAsync<Contact>(ApplicationDbContext);
        }

        public IRepositoryAsync<Phone> GetInMemoryPhoneRepository()
        {
            return new ApplicationRepositoryAsync<Phone>(ApplicationDbContext);
        }

        public IRepositoryAsync<Address> GetInMemoryAddressRepository()
        {
            return new ApplicationRepositoryAsync<Address>(ApplicationDbContext);
        }

        public async void SeedData()
        {
            await ApplicationDbContextSeed.SeedSampleDataAsync(ApplicationDbContext);
        }

        public IMapper GetMapper()
        {
            var mockMapper = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
            var mapper = mockMapper.CreateMapper();
            return mapper;
        }

    }
}

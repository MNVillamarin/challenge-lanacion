namespace LaNacion.Application.UnitTests.Helpers
{
    public class Helper
    {
        private readonly ApplicationDbContext ApplicationDbContext;
        private readonly IDateTimeService dataTimeService;

        public Helper()
        {
            dataTimeService = new DateTimeService();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseInMemoryDatabase($"{Guid.NewGuid()}.{Guid.NewGuid()}");

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

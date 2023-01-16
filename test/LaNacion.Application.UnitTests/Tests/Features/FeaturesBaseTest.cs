using LaNacion.Application.UnitTests.Helpers;

namespace LaNacion.Application.UnitTests.Tests.Features
{
    public abstract class FeaturesBaseTest
    {
        protected readonly Helper _helper;
        protected readonly IMapper _mapper;
        protected readonly IRepositoryAsync<Contact> _contactRepository;
        protected readonly IRepositoryAsync<Phone> _phoneRepository;
        protected readonly IRepositoryAsync<Address> _addressRepository;

        public FeaturesBaseTest()
        {
            _helper = new Helper();
            _mapper = _helper.GetMapper();
            _contactRepository = _helper.GetInMemoryContactRepository();
            _addressRepository = _helper.GetInMemoryAddressRepository();
            _phoneRepository = _helper.GetInMemoryPhoneRepository();
        }

    }
}

using LaNacion.Application.Interfaces;

namespace LaNacion.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime LocalUtc => DateTime.UtcNow;
    }
}

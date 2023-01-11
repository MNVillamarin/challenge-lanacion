using Ardalis.Specification.EntityFrameworkCore;
using LaNacion.Application.Interfaces;
using LaNacion.Persistence.Contexts;

namespace LaNacion.Persistence.Repository
{
    public class ApplicationRepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public ApplicationRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

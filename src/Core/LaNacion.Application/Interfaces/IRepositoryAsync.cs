using Ardalis.Specification;

namespace LaNacion.Application.Interfaces
{
    public interface IRepositoryAsync<T> : IRepositoryBase<T> where T : class
    {
    }
}

using System.Linq.Expressions;

namespace EM.Domain.Services.Common
{
    /// <summary>
    /// The data services.
    /// </summary>

    public interface IDataServices<T>
    {

        IQueryable<T> GetAll(Expression<Func<T, bool>> match);
        Task<ICollection<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(int id);
    }
}
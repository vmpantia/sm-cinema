using System.Linq.Expressions;

namespace SMCinema.Domain.Contracts
{
    public interface IBaseRepository<TModel> where TModel : class
    {
        Task<Guid> AddAsync(TModel model, string requestor);
        Task DeleteAsync(Guid id, string requestor);
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<IEnumerable<TModel>> GetByExpressionAsync(Expression<Func<TModel, bool>> expression);
        Task<TModel?> GetOneByExpressionAsync(Expression<Func<TModel, bool>> expression);
        Task UpdateAsync(TModel model, string requestor);
    }
}
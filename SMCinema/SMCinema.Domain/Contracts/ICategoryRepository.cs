using SMCinema.Domain.Models;
using System.Linq.Expressions;

namespace SMCinema.Domain.Contracts
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<IEnumerable<Category>> GetCategoriesByExpressionAsync(Expression<Func<Category, bool>> expression);
        Task<Category?> GetCategoryByExpressionAsync(Expression<Func<Category, bool>> expression);
        Task<Guid> AddCategoryAsync(Category category, string requestor);
        Task UpdateCategoryAsync(Category category, string requestor);
        Task DeleteCategoryAsync(Guid id, string requestor);
    }
}
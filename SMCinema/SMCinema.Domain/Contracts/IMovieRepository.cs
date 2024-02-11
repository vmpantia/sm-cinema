using SMCinema.Domain.Models;
using System.Linq.Expressions;

namespace SMCinema.Domain.Contracts
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<IEnumerable<Movie>> GetMoviesByExpressionAsync(Expression<Func<Movie, bool>> expression);
        Task<Movie?> GetMovieByExpressionAsync(Expression<Func<Movie, bool>> expression);
        Task<Guid> AddMovieAsync(Movie movie, string requestor);
        Task UpdateMovieAsync(Movie movie, string requestor);
        Task DeleteMovieAsync(Guid id, string requestor);
    }
}
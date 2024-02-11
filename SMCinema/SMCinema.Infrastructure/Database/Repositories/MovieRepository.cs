using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMCinema.Infrastructure.Database.Contexts;
using System.Linq.Expressions;
using SMCinema.Domain.Models;
using SMCinema.Domain.Contracts;
using SMCinema.Domain.Enumerations.Statuses;

namespace SMCinema.Infrastructure.Database.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly SMCinemaDbContext _context;
        private readonly IMapper _mapper;
        public MovieRepository(SMCinemaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync() =>
            await _context.Movies.Include(tbl => tbl.Category)
                                     .ProjectTo<Movie>(_mapper.ConfigurationProvider)
                                     .AsNoTracking()
                                     .AsSplitQuery()
                                     .ToListAsync();

        public async Task<IEnumerable<Movie>> GetMoviesByExpressionAsync(Expression<Func<Movie, bool>> expression) =>
            await _context.Movies.Include(tbl => tbl.Category)
                                     .ProjectTo<Movie>(_mapper.ConfigurationProvider)
                                     .Where(expression)
                                     .AsNoTracking()
                                     .AsSplitQuery()
                                     .ToListAsync();

        public async Task<Movie?> GetMovieByExpressionAsync(Expression<Func<Movie, bool>> expression) =>
            await _context.Movies.ProjectTo<Movie>(_mapper.ConfigurationProvider)
                                     .FirstOrDefaultAsync(expression);

        public async Task<Guid> AddMovieAsync(Movie movie, string requestor)
        {
            // Add Entity
            var entity = _mapper.Map<Entities.Movie>(movie);
            entity.CreatedAt = DateTime.Now;
            entity.CreatedBy = requestor;

            await _context.Movies.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task UpdateMovieAsync(Movie movie, string requestor)
        {
            var entity = await _context.Movies.FindAsync(movie.Id);
            if (entity == null)
                throw new Exception("Movie cannot found in the database.");

            // Update Entity
            var updated = _mapper.Map(movie, entity);
            updated.UpdatedAt = DateTime.Now;
            updated.UpdatedBy = requestor;

            _context.Movies.Update(updated);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(Guid id, string requestor)
        {
            var entity = await _context.Movies.FindAsync(id);
            if (entity == null)
                throw new Exception("Movie cannot found in the database.");

            // Soft-Delete Entity
            entity.Status = MovieStatus.Deleted;
            entity.UpdatedAt = DateTime.Now;
            entity.UpdatedBy = requestor;

            _context.Movies.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

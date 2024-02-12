using AutoMapper;
using SMCinema.Infrastructure.Database.Contexts;
using SMCinema.Domain.Models;
using SMCinema.Domain.Enumerations.Statuses;
using SMCinema.Domain.Contracts;
using SMCinema.Infrastructure.Database.Common;

namespace SMCinema.Infrastructure.Database.Repositories
{
    public class MovieRepository : BaseRepository<Entities.Movie, Movie>, IMovieRepository
    {
        public MovieRepository(SMCinemaDbContext context, IMapper mapper) : base(context, mapper) { }

        public async override Task DeleteAsync(Guid id, string requestor)
        {
            var entity = await _entities.FindAsync(id);
            if (entity == null)
                throw new Exception("Movie cannot found in the database.");

            // Soft-Delete Entity
            entity.Status = MovieStatus.Deleted;
            entity.UpdatedAt = DateTime.Now;
            entity.UpdatedBy = requestor;

            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

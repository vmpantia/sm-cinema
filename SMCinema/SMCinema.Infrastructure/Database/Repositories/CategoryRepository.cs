using AutoMapper;
using SMCinema.Domain.Contracts;
using SMCinema.Domain.Enumerations.Statuses;
using SMCinema.Domain.Models;
using SMCinema.Infrastructure.Database.Common;
using SMCinema.Infrastructure.Database.Contexts;

namespace SMCinema.Infrastructure.Database.Repositories
{
    public class CategoryRepository : BaseRepository<Entities.Category, Category>, ICategoryRepository
    {
        public CategoryRepository(SMCinemaDbContext context, IMapper mapper) : base(context, mapper) { }

        public async override Task DeleteAsync(Guid id, string requestor)
        {
            var entity = await _entities.FindAsync(id);
            if (entity == null)
                throw new Exception("Category cannot found in the database.");

            // Soft-Delete Entity
            entity.Status = CategoryStatus.Deleted;
            entity.UpdatedAt = DateTime.Now;
            entity.UpdatedBy = requestor;

            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

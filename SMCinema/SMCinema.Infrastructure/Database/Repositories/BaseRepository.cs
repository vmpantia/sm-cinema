using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SMCinema.Domain.Contracts;
using SMCinema.Infrastructure.Database.Contexts;
using System.Linq.Expressions;

namespace SMCinema.Infrastructure.Database.Repositories
{
    public abstract class BaseRepository<TEntity, TModel> : IBaseRepository<TModel> 
        where TEntity : class, IEntity
        where TModel : class
    {
        protected readonly SMCinemaDbContext _context;
        protected readonly IMapper _mapper;
        protected readonly DbSet<TEntity> _entities;
        public BaseRepository(SMCinemaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _entities = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TModel>> GetAllAsync() =>
            await _entities.ProjectTo<TModel>(_mapper.ConfigurationProvider)
                           .AsNoTracking()
                           .AsSplitQuery()
                           .ToListAsync();

        public virtual async Task<IEnumerable<TModel>> GetByExpressionAsync(Expression<Func<TModel, bool>> expression) =>
            await _entities.ProjectTo<TModel>(_mapper.ConfigurationProvider)
                           .Where(expression)
                           .AsNoTracking()
                           .AsSplitQuery()
                           .ToListAsync();

        public virtual async Task<TModel?> GetOneByExpressionAsync(Expression<Func<TModel, bool>> expression) =>
            await _entities.ProjectTo<TModel>(_mapper.ConfigurationProvider)
                           .FirstOrDefaultAsync(expression);

        public virtual async Task<Guid> AddAsync(TModel model, string requestor)
        {
            // Add Entity
            var entity = _mapper.Map<TEntity>(model);
            entity.CreatedAt = DateTime.Now;
            entity.CreatedBy = requestor;

            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public virtual async Task UpdateAsync(TModel model, string requestor)
        {
            var latestEntity = _mapper.Map<TEntity>(model);
            var currentEntity = await _entities.FindAsync(latestEntity.Id);
            if (currentEntity == null)
                throw new Exception($"{nameof(TEntity)} cannot found in the database.");

            // Update Entity
            var updated = _mapper.Map(latestEntity, currentEntity);
            updated.UpdatedAt = DateTime.Now;
            updated.UpdatedBy = requestor;

            _entities.Update(updated);
            await _context.SaveChangesAsync();
        }

        public abstract Task DeleteAsync(Guid id, string requestor);
    }
}

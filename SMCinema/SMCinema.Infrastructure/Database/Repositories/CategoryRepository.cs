using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SMCinema.Domain.Contracts;
using SMCinema.Domain.Enumerations.Statuses;
using SMCinema.Domain.Models;
using SMCinema.Infrastructure.Database.Contexts;
using System.Linq.Expressions;

namespace SMCinema.Infrastructure.Database.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SMCinemaDbContext _context;
        private readonly IMapper _mapper;
        public CategoryRepository(SMCinemaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync() =>
            await _context.Categories.Include(tbl => tbl.Movies)
                                     .ProjectTo<Category>(_mapper.ConfigurationProvider)
                                     .AsNoTracking()
                                     .AsSplitQuery()
                                     .ToListAsync();

        public async Task<IEnumerable<Category>> GetCategoriesByExpressionAsync(Expression<Func<Category, bool>> expression) =>
            await _context.Categories.Include(tbl => tbl.Movies)
                                     .ProjectTo<Category>(_mapper.ConfigurationProvider)
                                     .Where(expression)
                                     .AsNoTracking()
                                     .AsSplitQuery()
                                     .ToListAsync();

        public async Task<Category?> GetCategoryByExpressionAsync(Expression<Func<Category, bool>> expression) =>
            await _context.Categories.ProjectTo<Category>(_mapper.ConfigurationProvider)
                                     .FirstOrDefaultAsync(expression);

        public async Task<Guid> AddCategoryAsync(Category category, string requestor)
        {
            // Add Entity
            var entity = _mapper.Map<Entities.Category>(category);
            entity.CreatedAt = DateTime.Now;
            entity.CreatedBy = requestor;

            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task UpdateCategoryAsync(Category category, string requestor)
        {
            var entity = await _context.Categories.FindAsync(category.Id);
            if (entity == null)
                throw new Exception("Category cannot found in the database.");

            // Update Entity
            var updated = _mapper.Map(category, entity);
            updated.UpdatedAt = DateTime.Now;
            updated.UpdatedBy = requestor;

            _context.Categories.Update(updated);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(Guid id, string requestor)
        {
            var entity = await _context.Categories.FindAsync(id);
            if (entity == null)
                throw new Exception("Category cannot found in the database.");

            // Soft-Delete Entity
            entity.Status = CategoryStatus.Deleted;
            entity.UpdatedAt = DateTime.Now;
            entity.UpdatedBy = requestor;

            _context.Categories.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

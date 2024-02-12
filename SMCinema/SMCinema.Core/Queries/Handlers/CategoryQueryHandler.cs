using AutoMapper;
using MediatR;
using SMCinema.Core.Queries.Categories;
using SMCinema.Core.ViewModels.Categories;
using SMCinema.Domain.Contracts;
using SMCinema.Domain.Enumerations.Statuses;

namespace SMCinema.Core.Queries.Handlers
{
    public class CategoryQueryHandler :
        IRequestHandler<GetCategoryByIdQuery, CategoryViewModel>,
        IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryViewModel>>,
        IRequestHandler<GetAllCategoryLitesQuery, IEnumerable<CategoryLiteViewModel>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryViewModel> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            // Get category from the database
            var category = await _categoryRepository.GetOneByExpressionAsync(data => data.Id == request.Id &&
                                                                                     data.Status == CategoryStatus.Active);

            // Check if category is exist
            if (category is null)
                throw new ArgumentNullException(nameof(category));

            // Map category to CategoryViewModel
            return _mapper.Map<CategoryViewModel>(category);
        }

        public async Task<IEnumerable<CategoryViewModel>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            // Get categories from the database
            var categories = await _categoryRepository.GetByExpressionAsync(data => data.Status == CategoryStatus.Active);

            // Map categories to list of CategoryViewModel
            return _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
        }

        public async Task<IEnumerable<CategoryLiteViewModel>> Handle(GetAllCategoryLitesQuery request, CancellationToken cancellationToken)
        {
            // Get categories from the database
            var categories = await _categoryRepository.GetByExpressionAsync(data => data.Status == CategoryStatus.Active);

            // Map categories to list of CategoryLiteViewModel
            return _mapper.Map<IEnumerable<CategoryLiteViewModel>>(categories);
        }
    }
}

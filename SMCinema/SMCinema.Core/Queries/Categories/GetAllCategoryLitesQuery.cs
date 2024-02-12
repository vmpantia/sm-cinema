using MediatR;
using SMCinema.Core.ViewModels.Categories;
using SMCinema.Core.ViewModels.Movies;

namespace SMCinema.Core.Queries.Categories
{
    public class GetAllCategoryLitesQuery : IRequest<IEnumerable<CategoryLiteViewModel>> { }
}

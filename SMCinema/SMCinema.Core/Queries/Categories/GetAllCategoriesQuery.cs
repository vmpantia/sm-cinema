using MediatR;
using SMCinema.Core.ViewModels.Categories;

namespace SMCinema.Core.Queries.Categories
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryViewModel>> { }
}

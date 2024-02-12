using MediatR;
using SMCinema.Core.ViewModels.Categories;

namespace SMCinema.Core.Queries.Categories
{
    public class GetCategoryByIdQuery : IRequest<CategoryViewModel>
    {
        public GetCategoryByIdQuery(Guid id) => Id = id;

        public Guid Id { get; set; }
    }
}

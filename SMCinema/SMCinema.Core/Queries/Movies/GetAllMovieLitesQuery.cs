using MediatR;
using SMCinema.Core.ViewModels.Movies;

namespace SMCinema.Core.Queries.Movies
{
    public class GetAllMovieLitesQuery : IRequest<IEnumerable<MovieLiteViewModel>> { }
}

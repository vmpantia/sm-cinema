using MediatR;
using SMCinema.Core.ViewModels.Movies;

namespace SMCinema.Core.Queries.Movies
{
    public class GetMovieByIdQuery : IRequest<MovieViewModel>
    {
        public GetMovieByIdQuery(Guid id) => Id = id;   

        public Guid Id { get; set; }
    }
}

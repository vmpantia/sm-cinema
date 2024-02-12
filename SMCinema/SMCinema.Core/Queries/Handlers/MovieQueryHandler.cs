using AutoMapper;
using MediatR;
using SMCinema.Core.Queries.Movies;
using SMCinema.Core.ViewModels.Movies;
using SMCinema.Domain.Contracts;
using SMCinema.Domain.Enumerations.Statuses;

namespace SMCinema.Core.Queries.Handlers
{
    public class MovieQueryHandler :
        IRequestHandler<GetMovieByIdQuery, MovieViewModel>,
        IRequestHandler<GetAllMoviesQuery, IEnumerable<MovieViewModel>>,
        IRequestHandler<GetAllMovieLitesQuery, IEnumerable<MovieLiteViewModel>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieQueryHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<MovieViewModel> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            // Get movie from the database
            var movie = await _movieRepository.GetOneByExpressionAsync(data => data.Id == request.Id &&
                                                                               data.Status == MovieStatus.Active);

            // Check if movie is exist
            if(movie is null)
                throw new ArgumentNullException(nameof(movie));

            // Map movie to MovieViewModel
            return _mapper.Map<MovieViewModel>(movie);
        }

        public async Task<IEnumerable<MovieViewModel>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            // Get movies from the database
            var movies = await _movieRepository.GetByExpressionAsync(data => data.Status == MovieStatus.Active);

            // Check if movie is exist
            if (movies is null)
                throw new ArgumentNullException(nameof(movies));

            // Map movies to list of MovieViewModel
            return _mapper.Map<IEnumerable<MovieViewModel>>(movies);
        }

        public async Task<IEnumerable<MovieLiteViewModel>> Handle(GetAllMovieLitesQuery request, CancellationToken cancellationToken)
        {
            // Get movies from the database
            var movies = await _movieRepository.GetByExpressionAsync(data => data.Status == MovieStatus.Active);

            // Check if movie is exist
            if (movies is null)
                throw new ArgumentNullException(nameof(movies));

            // Map movies to list of MovieLiteViewModel
            return _mapper.Map<IEnumerable<MovieLiteViewModel>>(movies);
        }
    }
}

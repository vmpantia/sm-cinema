using AutoMapper;
using MediatR;
using SMCinema.Core.Commands.Models.Movie;
using SMCinema.Domain.Contracts;
using SMCinema.Domain.Models;

namespace SMCinema.Core.Commands.Handlers
{
    public class MovieCommandHandler :
        IRequestHandler<CreateCategoryCommand, Guid>,
        IRequestHandler<UpdateCategoryCommand>,
        IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieCommandHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var movie = _mapper.Map<Movie>(request);
            return await _movieRepository.AddAsync(movie, request.Requestor);
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var movie = _mapper.Map<Movie>(request);
            await _movieRepository.UpdateAsync(movie, request.Requestor);
        }

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken) =>
            await _movieRepository.DeleteAsync(request.Id, request.Requestor);
    }
}

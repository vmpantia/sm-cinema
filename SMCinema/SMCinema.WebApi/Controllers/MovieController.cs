using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMCinema.Core.Queries.Movies;
using SMCinema.Core.ViewModels.Movies;
using SMCinema.WebApi.Common;

namespace SMCinema.WebApi.Controllers
{
    public class MovieController : BaseController
    {
        public MovieController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

        [HttpGet]
        public async Task<IActionResult> GetMovies() =>
             await Handle<IEnumerable<MovieViewModel>>(new GetAllMoviesQuery());
    }
}

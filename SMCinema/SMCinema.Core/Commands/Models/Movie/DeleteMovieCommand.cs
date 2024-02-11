using MediatR;

namespace SMCinema.Core.Commands.Models.Movie
{
    public class DeleteMovieCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Requestor { get; set; }
    }
}

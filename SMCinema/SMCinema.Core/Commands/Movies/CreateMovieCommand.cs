using MediatR;

namespace SMCinema.Core.Commands.Movies
{
    public class CreateMovieCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }
        public string Requestor { get; set; }
    }
}

using MediatR;
using SMCinema.Domain.Enumerations.Statuses;

namespace SMCinema.Core.Commands.Models.Movie
{
    public class UpdateMovieCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public MovieStatus Status { get; set; }
        public Guid CategoryId { get; set; }
        public string Requestor { get; set; }
    }
}

using SMCinema.Domain.Enumerations.Statuses;

namespace SMCinema.Core.ViewModels.Movies
{
    public class MovieViewModel
    {
        // Movie Details
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public MovieStatus Status { get; set; }

        // Category Details
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }

        // Common
        public DateTime LastUpdateAt { get; set; }
        public string LastUpdateBy { get; set; }
    }
}

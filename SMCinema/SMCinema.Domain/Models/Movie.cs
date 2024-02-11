using SMCinema.Domain.Enumerations.Statuses;

namespace SMCinema.Domain.Models
{
    public class Movie
    {
        public Movie(string name, string? description, MovieStatus status, Guid categoryId)
        {
            Name = name;
            Description = description;
            Status = status;
            CategoryId = categoryId;
        }

        public Movie(Guid id, string name, string? description, MovieStatus status, Guid categoryId)
            : this(name, description, status, categoryId)
        {
            Id = id;
        }

        public Guid Id { get; init; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public MovieStatus Status { get; private set; }
        public Guid CategoryId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public string? UpdatedBy { get; private set; }

        public virtual Category Category { get; private set; }
    }
}

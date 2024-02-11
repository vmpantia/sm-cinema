using SMCinema.Domain.Enumerations.Statuses;

namespace SMCinema.Domain.Models
{
    public class Category
    {
        public Category(string name, string? description, CategoryStatus status)
        {
            Name = name;
            Description = description;
            Status = status;
        }

        public Category(Guid id, string name, string? description, CategoryStatus status)
            : this(name, description, status)
        {
            Id = id;
        }

        public Guid Id { get; init; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public CategoryStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public string? UpdatedBy { get; private set; }

        public virtual ICollection<Movie> Movies { get; private set; }
    }
}

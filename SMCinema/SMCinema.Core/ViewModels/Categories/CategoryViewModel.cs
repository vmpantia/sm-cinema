using SMCinema.Domain.Enumerations.Statuses;

namespace SMCinema.Core.ViewModels.Categories
{
    public class CategoryViewModel
    {
        // Category Details
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public CategoryStatus Status { get; set; }

        // Common
        public DateTime LastUpdateAt { get; set; }
        public string LastUpdateBy { get; set; }
    }
}

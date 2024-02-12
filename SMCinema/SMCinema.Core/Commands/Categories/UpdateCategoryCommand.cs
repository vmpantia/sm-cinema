using MediatR;
using SMCinema.Domain.Enumerations.Statuses;

namespace SMCinema.Core.Commands.Categories
{
    public class UpdateCategoryCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public CategoryStatus Status { get; set; }
        public string Requestor { get; set; }
    }
}

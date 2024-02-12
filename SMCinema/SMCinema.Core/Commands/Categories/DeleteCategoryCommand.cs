using MediatR;

namespace SMCinema.Core.Commands.Categories
{
    public class DeleteCategoryCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Requestor { get; set; }
    }
}

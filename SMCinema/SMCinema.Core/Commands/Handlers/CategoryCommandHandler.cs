using AutoMapper;
using MediatR;
using SMCinema.Core.Commands.Categories;
using SMCinema.Domain.Contracts;
using SMCinema.Domain.Models;

namespace SMCinema.Core.Commands.Handlers
{
    public class CategoryCommandHandler :
        IRequestHandler<CreateCategoryCommand, Guid>,
        IRequestHandler<UpdateCategoryCommand>,
        IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var movie = _mapper.Map<Category>(request);
            return await _categoryRepository.AddAsync(movie, request.Requestor);
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var movie = _mapper.Map<Category>(request);
            await _categoryRepository.UpdateAsync(movie, request.Requestor);
        }

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken) =>
            await _categoryRepository.DeleteAsync(request.Id, request.Requestor);
    }
}

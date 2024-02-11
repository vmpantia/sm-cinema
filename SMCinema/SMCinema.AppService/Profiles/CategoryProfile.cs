using AutoMapper;
using SMCinema.Core.Commands.Models.Movie;
using SMCinema.Domain.Enumerations.Statuses;
using SMCinema.Domain.Models;

namespace SMCinema.AppService.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryCommand, Category>()
                .ForMember(dst => dst.CreatedAt, opt => opt.Ignore())
                .ForMember(dst => dst.CreatedBy, opt => opt.Ignore())
                .ForMember(dst => dst.UpdatedAt, opt => opt.Ignore())
                .ForMember(dst => dst.UpdatedBy, opt => opt.Ignore())
                .ForMember(dst => dst.Movies, opt => opt.Ignore())
                .ConstructUsing((src) => new Category(src.Name, src.Description, CategoryStatus.Active));

            CreateMap<UpdateCategoryCommand, Category>()
                .ForMember(dst => dst.CreatedAt, opt => opt.Ignore())
                .ForMember(dst => dst.CreatedBy, opt => opt.Ignore())
                .ForMember(dst => dst.UpdatedAt, opt => opt.Ignore())
                .ForMember(dst => dst.UpdatedBy, opt => opt.Ignore())
                .ForMember(dst => dst.Movies, opt => opt.Ignore())
                .ConstructUsing((src) => new Category(src.Id, src.Name, src.Description, src.Status));
        }
    }
}

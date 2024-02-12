using AutoMapper;
using SMCinema.Core.Commands.Movies;
using SMCinema.Core.ViewModels.Movies;
using SMCinema.Domain.Enumerations.Statuses;
using SMCinema.Domain.Models;

namespace SMCinema.AppService.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<CreateMovieCommand, Movie>()
                .ForMember(dst => dst.CreatedAt, opt => opt.Ignore())
                .ForMember(dst => dst.CreatedBy, opt => opt.Ignore())
                .ForMember(dst => dst.UpdatedAt, opt => opt.Ignore())
                .ForMember(dst => dst.UpdatedBy, opt => opt.Ignore())
                .ForMember(dst => dst.Category, opt => opt.Ignore())
                .ConstructUsing((src) => new Movie(src.Name, src.Description, MovieStatus.Active, src.CategoryId));

            CreateMap<UpdateMovieCommand, Movie>()
                .ForMember(dst => dst.CreatedAt, opt => opt.Ignore())
                .ForMember(dst => dst.CreatedBy, opt => opt.Ignore())
                .ForMember(dst => dst.UpdatedAt, opt => opt.Ignore())
                .ForMember(dst => dst.UpdatedBy, opt => opt.Ignore())
                .ForMember(dst => dst.Category, opt => opt.Ignore())
                .ConstructUsing((src) => new Movie(src.Id, src.Name, src.Description, src.Status, src.CategoryId));

            CreateMap<Movie, MovieViewModel>()
                .ForMember(dst => dst.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dst => dst.LastUpdateAt, opt => opt.MapFrom(src => src.UpdatedAt ?? src.CreatedAt))
                .ForMember(dst => dst.LastUpdateBy, opt => opt.MapFrom(src => src.UpdatedBy ?? src.CreatedBy));

            CreateMap<Movie, MovieLiteViewModel>();
        }
    }
}

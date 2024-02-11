﻿using AutoMapper;
using SMCinema.Core.Commands.Models.Movie;
using SMCinema.Domain.Enumerations.Statuses;
using SMCinema.Domain.Models;

namespace SMCinema.AppService.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<CreateCategoryCommand, Movie>()
                .ForMember(dst => dst.CreatedAt, opt => opt.Ignore())
                .ForMember(dst => dst.CreatedBy, opt => opt.Ignore())
                .ForMember(dst => dst.UpdatedAt, opt => opt.Ignore())
                .ForMember(dst => dst.UpdatedBy, opt => opt.Ignore())
                .ForMember(dst => dst.Category, opt => opt.Ignore())
                .ConstructUsing((src) => new Movie(src.Name, src.Description, MovieStatus.Active, src.CategoryId));

            CreateMap<UpdateCategoryCommand, Movie>()
                .ForMember(dst => dst.CreatedAt, opt => opt.Ignore())
                .ForMember(dst => dst.CreatedBy, opt => opt.Ignore())
                .ForMember(dst => dst.UpdatedAt, opt => opt.Ignore())
                .ForMember(dst => dst.UpdatedBy, opt => opt.Ignore())
                .ForMember(dst => dst.Category, opt => opt.Ignore())
                .ConstructUsing((src) => new Movie(src.Id, src.Name, src.Description, src.Status, src.CategoryId));
        }
    }
}
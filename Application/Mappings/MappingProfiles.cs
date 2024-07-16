using Application.Features.Courses.Commands.Create;
using Application.Features.Courses.Commands.Update;
using Application.Features.Courses.Queries.GetById;
using Application.Features.Courses.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings;
public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Course, CreateCourseCommand>().ReverseMap();
        CreateMap<Course, CreateCourseResponse>().ReverseMap();

        CreateMap<Course, GetListCourseItemDto>().ReverseMap();

        CreateMap<Course, GetByIdCourseResponse>().ReverseMap();

        CreateMap<Course, UpdateCourseCommand>().ReverseMap();
        CreateMap<Course, UpdateCourseResponse>().ReverseMap();
    }
}

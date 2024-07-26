using Application.Features.Applications.Create;
using Application.Features.Candidates.Commands.Create;
using Application.Features.Candidates.Commands.Update;
using Application.Features.Candidates.Queries.GetById;
using Application.Features.Candidates.Queries.GetList;
using Application.Features.Courses.Commands.Create;
using Application.Features.Courses.Commands.Update;
using Application.Features.Courses.Queries.GetById;
using Application.Features.Courses.Queries.GetList;
using Application.Features.Courses.Queries.GetListWithEnrollments;
using Application.Features.Enrollments.Commands.Approve;
using Application.Features.Enrollments.Commands.Create;
using Application.Features.Enrollments.Commands.Delete;
using Application.Features.Enrollments.Commands.Update;
using Application.Features.Enrollments.Queries.GetById;
using Application.Features.Enrollments.Queries.GetList;
using Application.Features.Users.Commands;
using AutoMapper;
using Domain.Entities;

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
        CreateMap<Course, GetListCourseWithEnrollmentsItemDto>().ReverseMap();

        CreateMap<AppUser, CreateUserCommand>().ReverseMap();

        CreateMap<Candidate, GetListCandidateItemDto>().ReverseMap();
        CreateMap<Candidate, GetByIdCandidateResponse>().ReverseMap();
        CreateMap<Candidate, CreateCandidateCommand>().ReverseMap();
        CreateMap<Candidate, CreateCandidateResponse>().ReverseMap();
        CreateMap<Candidate, UpdateCandidateCommand>().ReverseMap();
        CreateMap<Candidate, UpdateCandidateResponse>().ReverseMap();
        CreateMap<Candidate, CreateApplicationCommand>().ReverseMap();

        CreateMap<Enrollment, GetListEnrollmentItemDto>().ReverseMap();
        CreateMap<Enrollment, GetByIdEnrollmentResponse>().ReverseMap();
        CreateMap<Enrollment, CreateEnrollmentCommand>().ReverseMap();
        CreateMap<Enrollment, CreateEnrollmentResponse>().ReverseMap();      
        CreateMap<Enrollment, UpdateEnrollmentCommand>().ReverseMap();
        CreateMap<Enrollment, UpdateEnrollmentResponse>().ReverseMap();
        CreateMap<Enrollment, ApproveEnrollmentCommand>().ReverseMap();
        CreateMap<Enrollment, ApproveEnrollmentResponse>().ReverseMap();
        CreateMap<Enrollment, CreateApplicationResponse>().ReverseMap();
        
    }
}

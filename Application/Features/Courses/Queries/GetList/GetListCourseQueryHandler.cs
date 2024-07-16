using Application.Common;
using AutoMapper;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using MediatR;

namespace Application.Features.Courses.Queries.GetList;

internal sealed class GetListCourseQueryHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetListCourseQuery, GetListResponse<GetListCourseItemDto>>
{
    public async Task<GetListResponse<GetListCourseItemDto>> Handle(GetListCourseQuery request, CancellationToken cancellationToken)
    {
        var courses = mapper.Map<List<GetListCourseItemDto>>(courseRepository.GetAll().ToList());
        return new GetListResponse<GetListCourseItemDto>() { Items = courses };
    }
}

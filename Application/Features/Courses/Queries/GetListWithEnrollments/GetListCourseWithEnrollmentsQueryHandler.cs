using Application.Common;
using AutoMapper;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using MediatR;

namespace Application.Features.Courses.Queries.GetListWithEnrollments;

internal sealed class GetListCourseWithEnrollmentsQueryHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetListCourseWithEnrollmentsQuery, GetListResponse<GetListCourseWithEnrollmentsItemDto>>
{
    public async Task<GetListResponse<GetListCourseWithEnrollmentsItemDto>> Handle(GetListCourseWithEnrollmentsQuery request, CancellationToken cancellationToken)
    {
        var courses = mapper.Map<List<GetListCourseWithEnrollmentsItemDto>>(await courseRepository.GetAllCourseWithEnrollmentsAsync());
        return new GetListResponse<GetListCourseWithEnrollmentsItemDto>() { Items = courses };
    }
}

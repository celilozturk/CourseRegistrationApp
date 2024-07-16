using AutoMapper;
using Domain.Abstractions.Repositories;
using MediatR;

namespace Application.Features.Courses.Queries.GetById;

internal sealed class GetByIdCourseQueryHandler(ICourseRepository courseRepository, IMapper mapper) : IRequestHandler<GetByIdCourseQuery, GetByIdCourseResponse>
{
    public async Task<GetByIdCourseResponse> Handle(GetByIdCourseQuery request, CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdAsync(request.Id, cancellationToken);
        return mapper.Map<GetByIdCourseResponse>(course);
    }
}


using Application.Features.Applications.Rules;
using Domain.Abstractions.Repositories;
using MediatR;

namespace Application.Features.Applications.Queries.GetCountByCourseId;

internal sealed class GetCountByCourseIdApplicationQueryHandler (IEnrollmentRepository enrollmentRepository,ICourseRepository courseRepository,ApplicationBusinessRules applicationBusinessRules): IRequestHandler<GetCountByCourseIdApplicationQuery, GetCountByCourseIdApplicationResponse>
{
    public async Task<GetCountByCourseIdApplicationResponse> Handle(GetCountByCourseIdApplicationQuery request, CancellationToken cancellationToken)
    {
        await applicationBusinessRules.CheckIfCourseIsExist(request.courseId);
        var applicationCount = enrollmentRepository.Where(x => x.CourseId == request.courseId).Count();
        var course = await courseRepository.GetByIdAsync(request.courseId, cancellationToken);
        return new GetCountByCourseIdApplicationResponse { ApplicationCount = applicationCount, TotalParticipants=course.TotalPaticipants, CourseId=request.courseId };
    }
}
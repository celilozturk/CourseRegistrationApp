using AutoMapper;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Courses.Commands.Update;

internal sealed class UpdateCourseCommandHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateCourseCommand, UpdateCourseResponse>
{
    public async Task<UpdateCourseResponse> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = mapper.Map<Course>(request);
        course.UpdatedDate = DateTime.UtcNow;
        courseRepository.Update(course);
        unitOfWork.Commmit();

        return mapper.Map<UpdateCourseResponse>(course) ;
    }
}

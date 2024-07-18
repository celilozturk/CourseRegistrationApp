using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.Common.Exceptions;
using MediatR;

namespace Application.Features.Courses.Commands.Delete;

internal sealed class DeleteCourseCommandHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteCourseCommand, DeleteCourseResponse>
{
    public async Task<DeleteCourseResponse> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        
        //throw new BadRequestException("Bad request");
        var course= await courseRepository.GetByIdAsync(request.Id, cancellationToken);
        if (course is null)
        {
            throw new CourseNotFoundException(request.Id);
        }
        courseRepository.Delete(course);
        unitOfWork.Commmit();
        return new DeleteCourseResponse(course.Id); 
    }
}

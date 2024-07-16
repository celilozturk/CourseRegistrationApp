using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using MediatR;

namespace Application.Features.Courses.Commands.Delete;

internal sealed class DeleteCourseCommandHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteCourseCommand, DeleteCourseResponse>
{
    public async Task<DeleteCourseResponse> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        var course= await courseRepository.GetByIdAsync(request.Id, cancellationToken);
        courseRepository.Delete(course);
        unitOfWork.Commmit();
        return new DeleteCourseResponse(course.Id); 
    }
}

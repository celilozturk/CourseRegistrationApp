using AutoMapper;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Courses.Commands.Create;

internal sealed class CreateCourseCommandHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateCourseCommand, CreateCourseResponse>
{
    public async Task<CreateCourseResponse> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var course= mapper.Map<Course>(request);   

        await courseRepository.CreateAsync(course,cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);
        return mapper.Map<CreateCourseResponse>(course);

    }
}

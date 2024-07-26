using Application.Features.Applications.Rules;
using AutoMapper;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Applications.Create;

internal sealed class CreateApplicationCommandHandler(ICourseRepository courseRepository, IEnrollmentRepository enrollmentRepository, ICandidateRepository candidateRepository,IUnitOfWork unitOfWork,ApplicationBusinessRules applicationBusinessRules,IMapper mapper) : IRequestHandler<CreateApplicationCommand, CreateApplicationResponse>
{
    public  async Task<CreateApplicationResponse> Handle(CreateApplicationCommand request, CancellationToken cancellationToken)
    {
        
        await applicationBusinessRules.CheckIfCourseIsExist(request.CourseId);
        int candidateId =await applicationBusinessRules.CheckIfCandidateIsExistOrCreateAsync(request);
        var enrollment=new Enrollment() { CourseId=request.CourseId, CandidateId=candidateId };
        await applicationBusinessRules.CheckIfCourseIsAssignedAsync(enrollment);
         enrollment=await enrollmentRepository.CreateAsync(enrollment,cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);
        return mapper.Map<CreateApplicationResponse>(enrollment) ;
    }
}

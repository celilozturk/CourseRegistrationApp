using Application.Features.Applications.Create;
using Application.Features.Enrollments.Commands.Create;
using AutoMapper;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.Common;
using Domain.Common.Exceptions;
using Domain.Common.Exceptions.Base;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Applications.Rules;
internal class ApplicationBusinessRules(ICandidateRepository candidateRepository, ICourseRepository courseRepository,IEnrollmentRepository enrollmentRepository, IMapper mapper,IUnitOfWork unitOfWork) : BaseBusinessRules
{
    //CancellationToken cancellationToken = CancellationToken.None;
    public async Task<int> CheckIfCandidateIsExistOrCreateAsync(CreateApplicationCommand command)
    {
        if (await candidateRepository.AnyAsync(x => x.Email == command.Email))
        {
            var candidate = await candidateRepository.GetByEmailAsync(command.Email);
            return candidate.Id;
        }
        var candidateModel = mapper.Map<Candidate>(command);
        var newCandidate = await CreateNewCandidate(candidateModel);
        return newCandidate.Id;
    }

    public async Task CheckIfCourseIsExist(int courseId)
    {
        CancellationToken cancellationToken = CancellationToken.None;
        var course = await courseRepository.GetByIdAsync(courseId, cancellationToken);
        if (course is null)
        {
            throw new CourseNotFoundException(courseId);
        }
    }
    public async Task CheckIfUserHasAppliedAsync(Enrollment enrollment)
    {      
        var result = enrollmentRepository.Where(x => x.CandidateId == enrollment.CandidateId && x.CourseId == enrollment.CourseId).ToList();
        if (result.Count() > 0) throw new BusinessException("User has already applied!");

    }
    private async Task<Candidate> CreateNewCandidate(Candidate candidate)
    {
        CancellationToken cancellationToken = CancellationToken.None;
        await candidateRepository.CreateAsync(candidate, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);
        return candidate;

    }
}

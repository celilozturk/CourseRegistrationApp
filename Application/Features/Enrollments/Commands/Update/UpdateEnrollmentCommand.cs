using AutoMapper;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.Common.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Enrollments.Commands.Update;
public record  UpdateEnrollmentCommand(int Id, int CandidateId, int CourseId):IRequest<UpdateEnrollmentResponse>;

internal sealed class UpdateEnrollmentCommandHandler (IEnrollmentRepository enrollmentRepository, IUnitOfWork unitOfWork, IMapper mapper): IRequestHandler<UpdateEnrollmentCommand, UpdateEnrollmentResponse>
{
    public async Task<UpdateEnrollmentResponse> Handle(UpdateEnrollmentCommand request, CancellationToken cancellationToken)
    {
        Enrollment? enrollment = await enrollmentRepository.GetByIdAsync(request.Id,cancellationToken);
        if(enrollment is null)
        {
            throw new EnrollmentNotFoundException(request.Id);
        }
        enrollment = mapper.Map(request, enrollment);
        enrollment.UpdatedDate = DateTime.UtcNow;
        enrollmentRepository.Update(enrollment);
        unitOfWork.Commmit();
        return mapper.Map<UpdateEnrollmentResponse>(enrollment);
    }
}

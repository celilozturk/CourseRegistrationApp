using Application.Features.Enrollments.Rules;
using AutoMapper;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.Common.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Features.Enrollments.Commands.Approve;

internal sealed class ApproveEnrollmentCommandHandler (IEnrollmentRepository enrollmentRepository,IUnitOfWork unitOfWork, IMapper mapper,EnrollmentBusinessRules enrollmentBusinessRules): IRequestHandler<ApproveEnrollmentCommand, ApproveEnrollmentResponse>
{
    public async Task<ApproveEnrollmentResponse> Handle(ApproveEnrollmentCommand request, CancellationToken cancellationToken)
    {
        var enrollment =await  enrollmentRepository.GetByIdAsync(request.Id,cancellationToken);
        if (enrollment is null)
        {
            throw new EnrollmentNotFoundException(request.Id);
        }
        if (!enrollment.IsApproved)
        {
            enrollment = mapper.Map(request, enrollment);
            enrollment.IsApproved = true;
            enrollmentRepository.Update(enrollment);
            unitOfWork.Commmit();
        }
        
        return mapper.Map<ApproveEnrollmentResponse>(enrollment);
    }
}

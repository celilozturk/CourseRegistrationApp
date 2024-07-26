using Application.Features.Enrollments.Commands.Approve;
using Domain.Abstractions.Repositories;
using Domain.Common;
using Domain.Common.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Enrollments.Rules;
public class EnrollmentBusinessRules(IEnrollmentRepository enrollmentRepository) : BaseBusinessRules
{
   
    //public async Task CheckEnrollmentInfoIsValid(ApproveEnrollmentCommand command)
    //{
    //    CancellationToken cancellationToken = CancellationToken.None;
    //     enrollment = await enrollmentRepository.GetByIdAsync(command.Id, cancellationToken);

    //    if (enrollment == null || (command.CourseId != enrollment.CourseId) || (command.CandidateId != enrollment.CandidateId))
    //    {
    //        throw new EnrollmentNotFoundException(command.Id);
    //    }
    //}
   
}

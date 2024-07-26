using Application.Features.Enrollments.Commands.Approve;
using Application.Features.Enrollments.Commands.Create;
using Domain.Abstractions.Repositories;
using Domain.Common;
using Domain.Common.Exceptions;
using Domain.Common.Exceptions.Base;
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
   public async Task CheckIfCourseIsAssignedAsync(CreateEnrollmentCommand command)
    {
        if(command is null)
        {
            throw new EnrollmentNullException();
        }
      
        var enrollment =  enrollmentRepository.Where(x => x.CandidateId == command.CandidateId && x.CourseId == command.CourseId).ToList();
        if (enrollment.Count() > 0)  throw new BusinessException("Enrollment was already assigned !");
        
    }
   
}

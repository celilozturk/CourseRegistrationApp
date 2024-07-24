using Application.Features.Candidates.Commands.Create;
using Application.Features.Candidates.Rules;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Enrollments.Commands.Create;
public record CreateEnrollmentCommand(int CourseId,int CandidateId ) :IRequest<CreateEnrollmentResponse>;

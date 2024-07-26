using Domain.Common.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Enrollments.Commands.Approve;
public record ApproveEnrollmentCommand : IRequest<ApproveEnrollmentResponse>
{
    public int Id { get; set; }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Enrollments.Queries.GetById;
public record GetByIdEnrollmentQuery : IRequest<GetByIdEnrollmentResponse>
{
    public int Id { get; set; }
}

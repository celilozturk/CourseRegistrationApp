using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Applications.Queries.GetCountByCourseId;
public record GetCountByCourseIdApplicationQuery : IRequest<GetCountByCourseIdApplicationResponse>
{
    public int courseId { get; set; }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Courses.Queries.GetById;
public record GetByIdCourseQuery:IRequest<GetByIdCourseResponse>
{
    public int Id { get; set; }
}


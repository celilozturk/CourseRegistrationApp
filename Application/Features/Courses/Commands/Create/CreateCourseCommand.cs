using Application.Behaviors.Caching;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Courses.Commands.Create;
public record CreateCourseCommand(string Name, int TotalPaticipants) : IRequest<CreateCourseResponse>, ICacheRemoverRequest
{
    public string? CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetCourses";
}

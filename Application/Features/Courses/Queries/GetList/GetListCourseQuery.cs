using Application.Behaviors.Caching;
using Application.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Courses.Queries.GetList;
public record GetListCourseQuery : IRequest<GetListResponse<GetListCourseItemDto>>, ICacheableRequest
{
    public string CacheKey => $"GetListCourseQuery(NotPaginated)";

    public bool BypassCache { get; }

    public string? CacheGroupKey => "GetCourses";
    public TimeSpan? SlidingExpiration { get; }
}

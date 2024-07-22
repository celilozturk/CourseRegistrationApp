using Application.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Courses.Queries.GetListWithEnrollments;
public record GetListCourseWithEnrollmentsQuery:IRequest<GetListResponse<GetListCourseWithEnrollmentsItemDto>>;

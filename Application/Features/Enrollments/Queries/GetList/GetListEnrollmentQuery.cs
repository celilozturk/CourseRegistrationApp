using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Enrollments.Queries.GetList;
public record GetListEnrollmentQuery():IRequest<GetListResponse<GetListEnrollmentItemDto>>;

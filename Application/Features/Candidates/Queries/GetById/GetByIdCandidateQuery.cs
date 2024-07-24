using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Candidates.Queries.GetById;
public record GetByIdCandidateQuery() : IRequest<GetByIdCandidateResponse>
{
    public int Id { get; set; }
}

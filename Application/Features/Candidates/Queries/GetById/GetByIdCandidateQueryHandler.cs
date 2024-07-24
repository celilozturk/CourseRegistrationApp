using AutoMapper;
using Domain.Abstractions.Repositories;
using Domain.Common.Exceptions;
using MediatR;

namespace Application.Features.Candidates.Queries.GetById;

internal sealed class GetByIdCandidateQueryHandler(ICandidateRepository candidateRepository,IMapper mapper) : IRequestHandler<GetByIdCandidateQuery, GetByIdCandidateResponse>
{
    public async Task<GetByIdCandidateResponse> Handle(GetByIdCandidateQuery request, CancellationToken cancellationToken)
    {
        var candidate= await candidateRepository.GetByIdAsync(request.Id, cancellationToken);
        if (candidate is null)
        {
            throw new CandidateNotFoundException(request.Id);
        }
          return mapper.Map<GetByIdCandidateResponse>(candidate); 
        
    }
}
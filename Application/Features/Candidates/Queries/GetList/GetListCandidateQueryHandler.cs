using Application.Common;
using AutoMapper;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using MediatR;

namespace Application.Features.Candidates.Queries.GetList;

internal sealed class GetListCandidateQueryHandler(ICandidateRepository candidateRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetListCandidateQuery, GetListResponse<GetListCandidateItemDto>>
{
    public async Task<GetListResponse<GetListCandidateItemDto>> Handle(GetListCandidateQuery request, CancellationToken cancellationToken)
    {
        var candidates =  mapper.Map<List<GetListCandidateItemDto>>( await candidateRepository.GetAllAsync());
        return new GetListResponse<GetListCandidateItemDto>() { Items = candidates };
    }
}
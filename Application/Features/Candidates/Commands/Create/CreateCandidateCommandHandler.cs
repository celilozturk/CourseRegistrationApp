using Application.Features.Candidates.Rules;
using AutoMapper;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Candidates.Commands.Create;

internal sealed class CreateCandidateCommandHandler(ICandidateRepository candidateRepository, IUnitOfWork unitOfWork, IMapper mapper, CandidateBusinessRules candidateBusinessRules) : IRequestHandler<CreateCandidateCommand, CreateCandidateResponse>
{
    public async Task<CreateCandidateResponse> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
    {
        await candidateBusinessRules.CheckIfEmailExist(request.Email);
        var candidate = mapper.Map<Candidate>(request);

        await candidateRepository.CreateAsync(candidate, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);
        return mapper.Map<CreateCandidateResponse>(candidate);
    }
}
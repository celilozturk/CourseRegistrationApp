using Application.Features.Candidates.Rules;
using AutoMapper;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.Common.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Features.Candidates.Commands.Update;

internal sealed class UpdateCandidateCommandHandler(ICandidateRepository candidateRepository, IUnitOfWork unitOfWork, IMapper mapper, CandidateBusinessRules candidateBusinessRules) : IRequestHandler<UpdateCandidateCommand, UpdateCandidateResponse>
{
    public async Task<UpdateCandidateResponse> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
    {
        Candidate? candidate = await candidateRepository.GetByIdAsync(request.Id,cancellationToken);
        if (candidate == null) {
            throw new CandidateNotFoundException(request.Id);
        }
        candidateBusinessRules.CheckIfEmailExist(candidate.Email);
        candidate = mapper.Map(request, candidate);
        candidate.UpdatedDate = DateTime.UtcNow;
        candidateRepository.Update(candidate);
        unitOfWork.Commmit();
        return new UpdateCandidateResponse();
    }
}
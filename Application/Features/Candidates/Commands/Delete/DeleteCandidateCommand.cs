using Application.Features.Candidates.Rules;
using AutoMapper;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.Common.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Candidates.Commands.Delete;
public record DeleteCandidateCommand(int Id):IRequest<DeleteCandidateResponse>;

internal sealed class DeleteCandidateCommandHandler(ICandidateRepository candidateRepository, IUnitOfWork unitOfWork, IMapper mapper, CandidateBusinessRules candidateBusinessRules) : IRequestHandler<DeleteCandidateCommand, DeleteCandidateResponse>
{
    public async Task<DeleteCandidateResponse> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
    {
        var candidate= await candidateRepository.GetByIdAsync(request.Id,cancellationToken);
        if(candidate is null)
        {
            throw new CandidateNotFoundException(request.Id);
        }
        candidateRepository.Delete(candidate);
        unitOfWork.Commmit();
        return new DeleteCandidateResponse(candidate.Id);
    }
}

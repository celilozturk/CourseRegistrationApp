using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Candidates.Commands.Delete;
public record DeleteCandidateCommand(int Id):IRequest<DeleteCandidateResponse>;

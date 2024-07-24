using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Candidates.Commands;
public record CreateCandidateCommand( string FirstName, string LastName, string Email, int Age):IRequest<CreateCandidateResponse>;

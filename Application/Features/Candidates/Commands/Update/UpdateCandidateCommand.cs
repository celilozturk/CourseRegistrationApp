using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Candidates.Commands.Update;
public record UpdateCandidateCommand(int Id,string FirstName, string LastName, string Email, int Age) :IRequest<UpdateCandidateResponse>;

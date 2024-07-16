using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Courses.Commands.Create;
public record CreateCourseCommand(string Name, int TotalParticipants):IRequest<CreateCourseResponse>;

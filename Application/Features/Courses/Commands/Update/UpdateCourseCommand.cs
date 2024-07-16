using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Courses.Commands.Update;
public record UpdateCourseCommand(int Id, string Name):IRequest<UpdateCourseResponse>;

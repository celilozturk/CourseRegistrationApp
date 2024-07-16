﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Courses.Commands.Delete;
public record DeleteCourseCommand(int Id):IRequest<DeleteCourseResponse>;

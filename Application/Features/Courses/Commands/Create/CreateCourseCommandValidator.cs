using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Courses.Commands.Create;
public class CreateCourseCommandValidator:AbstractValidator<CreateCourseCommand>
{
    public CreateCourseCommandValidator()
    {
        RuleFor(c=>c.Name).NotEmpty().MinimumLength(2).MaximumLength(100);
        RuleFor(c => c.TotalPaticipants).GreaterThan(0).NotEmpty();
    }
}

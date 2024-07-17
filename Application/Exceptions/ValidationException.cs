using Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions;
public class ValidationException:BadRequestException
{
    public ValidationException(Dictionary<string, string[]> errors) : base("Validation errors occured") => Errors = errors;

    public Dictionary<string, string[]> Errors { get; }
}

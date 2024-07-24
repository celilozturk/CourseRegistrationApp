using Domain.Common.Exceptions.Base;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Exceptions;
public class EnrollmentNotFoundException : NotFoundException
{
    public EnrollmentNotFoundException(int? enrollmentId) : base($"The enrollment identifier {enrollmentId} was not found!")
    {
    }
}

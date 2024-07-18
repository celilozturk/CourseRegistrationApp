using Domain.Common.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Exceptions;
public class CourseNotFoundException:NotFoundException
{
    public CourseNotFoundException(int courseId) : base($"The course identifier {courseId} was not found!")
    {
        
    }
}

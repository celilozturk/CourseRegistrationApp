using Domain.Abstractions.Repositories;
using Domain.Common;
using Domain.Common.Exceptions.Base;
using Domain.Entities;

namespace Application.Features.Courses.Rules;
internal class CourseBusinessRules(ICourseRepository courseRepository):BaseBusinessRules
{
    public async Task CourseNameCannotBeDuplicated(string courseName)
    {
        Course? result = await courseRepository.GetByNameAsync(courseName);
        if (result is not null) throw new BusinessException("Course Name exist!");
    }
}

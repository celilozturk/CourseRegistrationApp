using Domain.Entities;

namespace Application.Features.Courses.Queries.GetListWithEnrollments;

public class GetListCourseWithEnrollmentsItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int TotalPaticipants { get; set; }
    public DateTime CreatedDate { get; set; }
    public IEnumerable<Enrollment> Enrollments { get; set; }
}


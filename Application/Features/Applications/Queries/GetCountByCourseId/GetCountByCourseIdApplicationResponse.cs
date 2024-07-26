namespace Application.Features.Applications.Queries.GetCountByCourseId;

public class GetCountByCourseIdApplicationResponse
{
    public int CourseId { get; set; }
    public int TotalParticipants { get; set; }
    public int ApplicationCount { get; set; }

}
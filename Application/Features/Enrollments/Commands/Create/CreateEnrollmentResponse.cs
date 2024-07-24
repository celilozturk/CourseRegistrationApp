namespace Application.Features.Enrollments.Commands.Create;

public class CreateEnrollmentResponse
{
    public int CourseId { get; set; }
    public int CandidateId { get; set; }
    public bool IsApproved { get; set; }
}
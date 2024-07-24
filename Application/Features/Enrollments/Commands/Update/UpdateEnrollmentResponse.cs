namespace Application.Features.Enrollments.Commands.Update;

public class UpdateEnrollmentResponse
{
    public int CourseId { get; set; }
    public int CandidateId { get; set; }
    public bool IsApproved { get; set; }
}
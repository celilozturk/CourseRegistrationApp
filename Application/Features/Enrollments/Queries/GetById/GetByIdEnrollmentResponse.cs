using Domain.Entities;

namespace Application.Features.Enrollments.Queries.GetById;

public class GetByIdEnrollmentResponse
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int CandidateId { get; set; }
    public bool IsApproved { get; set; }
    //[JsonIgnore]
    public Course Course { get; set; }
    //[JsonIgnore]
    public Candidate Candidate { get; set; }
}
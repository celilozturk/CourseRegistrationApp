using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Features.Enrollments.Queries.GetList;
public class GetListEnrollmentItemDto
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

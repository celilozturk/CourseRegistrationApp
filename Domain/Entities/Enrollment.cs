using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Enrollment:BaseEntity<int>
{
    //[ForeignKey(nameof(Course))]
    public int CourseId { get; set; }
    //[ForeignKey(nameof(Candidate))]
    public int CandidateId { get; set; }
    public bool IsApproved { get; set; }
    public Course Course { get; set; }
    public Candidate Candidate { get; set; }
}

using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Enrollment:BaseEntity<int>
{
    public int CourseId { get; set; }
    public int CandidateId { get; set; }
    public bool IsApproved { get; set; }
    [JsonIgnore]
    public virtual Course Course { get; set; }
    [JsonIgnore]
    public virtual Candidate Candidate { get; set; }
}

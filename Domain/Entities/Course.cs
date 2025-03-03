﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Course:BaseEntity<int>
{
    public string Name { get; set; }
    public int TotalPaticipants { get; set; }
    [JsonIgnore]
    public virtual IEnumerable<Enrollment> Enrollments { get; set; }
}

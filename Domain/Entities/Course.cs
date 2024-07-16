using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Course:BaseEntity<int>
{
    public string Name { get; set; }
    public int TotalPaticipant { get; set; }
}

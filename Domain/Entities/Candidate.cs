using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Candidate:BaseEntity<int>
{
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => $"{FirstName} {LastName.ToUpper()}";
    public int Age { get; set; } = default;
    public IEnumerable<Enrollment> Enrollments { get; set; }
    public DateTime ApplyAt { get; set; }

    public Candidate()
    {
        ApplyAt= DateTime.Now;  
    }
}

using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repositories;
public interface IEnrollmentRepository:IGenericRepository<Enrollment,int>
{
    Task<IEnumerable<Enrollment>> GetAllAsync();
    Task<bool> AnyAsync(Expression<Func<Enrollment, bool>> expressions);
    Task<Enrollment> GetByIdWithCourseAndCandidate(int enrollmentId);
    Task<IEnumerable<Enrollment>> GetAllEnrollmentsWithCourseAndCandidateAsync();

}

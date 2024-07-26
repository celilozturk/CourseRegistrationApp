using Domain.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;
public class EnrollmentRepository : GenericRepository<Enrollment, int>, IEnrollmentRepository
{
    public EnrollmentRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<bool> AnyAsync(Expression<Func<Enrollment, bool>> expressions)
    {
        return await _appDbContext.Enrollments.AnyAsync(expressions);
    }

    public async Task<IEnumerable<Enrollment>> GetAllAsync()
    {
        return await _appDbContext.Enrollments.ToListAsync();
    }

    public async Task<Enrollment> GetByIdWithCourseAndCandidate(int enrollmentId)
    {
        return await _appDbContext.Enrollments.Include(x => x.Course).Include(x => x.Candidate).FirstOrDefaultAsync(x => x.Id == enrollmentId);
        
    }
    public async Task<IEnumerable<Enrollment>> GetAllEnrollmentsWithCourseAndCandidateAsync()
    {
        return await _appDbContext.Enrollments.Include(x => x.Course).Include(x=>x.Candidate).ToListAsync();
       
    }
}

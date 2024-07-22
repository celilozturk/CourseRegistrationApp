using Domain.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class CourseRepository : GenericRepository<Course, int>, ICourseRepository
{
    public CourseRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<IEnumerable<Course>> GetAllAsync()
    {
        return await _appDbContext.Courses.ToListAsync();
    }

    public async Task<Course> GetByNameAsync(string name)
    {
       return await _appDbContext.Courses.FirstOrDefaultAsync(c => c.Name == name);        
    }
    public async Task<IEnumerable<Course>> GetAllCourseWithEnrollmentsAsync()
    {
       return await _appDbContext.Courses.Include(x=>x.Enrollments).ToListAsync();
        //return await _appDbContext.Courses.Select(c => new { c.Id, c.Name, c.TotalPaticipants, Enrollment = c.Enrollments.Select(e => new {e.Candidate.FullName}).ToList() }).ToListAsync();
    }
}


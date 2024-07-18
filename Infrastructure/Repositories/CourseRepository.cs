using Domain.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;
public class CourseRepository : GenericRepository<Course, int>, ICourseRepository
{
    public CourseRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<Course> GetByNameAsync(string name)
    {
       return await _appDbContext.Courses.FirstOrDefaultAsync(c => c.Name == name);
        
    }
}

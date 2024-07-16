using Domain.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Contexts;
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
}

using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repositories;
public interface ICourseRepository:IGenericRepository<Course, int>
{
    Task<IEnumerable<Course>> GetAllAsync();
    Task<Course> GetByNameAsync(string name);
    Task<IEnumerable<Course>> GetAllCourseWithEnrollmentsAsync();
}

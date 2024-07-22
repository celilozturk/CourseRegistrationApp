using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repositories;
public interface IUserRoleRepository:IGenericRepository<AppUserRole,Guid>
{
    Task<IEnumerable<AppUserRole>> GetAllAsync();

    IQueryable<AppUserRole> Where(Expression<Func<AppUserRole, bool>> expression);
}

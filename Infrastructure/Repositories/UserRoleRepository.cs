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
internal sealed class UserRoleRepository : GenericRepository<AppUserRole, Guid>, IUserRoleRepository
{
    public UserRoleRepository(AppDbContext appDbContext) : base(appDbContext)
    {

    }

    public async Task<IEnumerable<AppUserRole>> GetAllAsync()
    {
       return await _appDbContext.UserRoles.ToListAsync();
    }

    public  IQueryable<AppUserRole> Where(Expression<Func<AppUserRole, bool>> expression)
    {
        return _appDbContext.UserRoles.Where(expression).AsQueryable();
    }
}

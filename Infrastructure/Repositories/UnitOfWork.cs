using Domain.Abstractions;
using Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appDbContext;

    public UnitOfWork(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task CommitAsync(CancellationToken cancellation = default)
    {
       await _appDbContext.SaveChangesAsync();
    }

    public void Commmit()
    {
        _appDbContext.SaveChanges();
    }
}

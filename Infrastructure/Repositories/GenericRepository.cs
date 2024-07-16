using Domain.Abstractions;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;
public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : class
{
    protected readonly AppDbContext _appDbContext;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        _dbSet = _appDbContext.Set<TEntity>();
    }
    public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(entity,cancellationToken);
        return entity;
    }   

    public IQueryable<TEntity> GetAll()
    {
        return _dbSet.AsNoTracking().AsQueryable();
    }

    public async Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity;
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }
    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }
}

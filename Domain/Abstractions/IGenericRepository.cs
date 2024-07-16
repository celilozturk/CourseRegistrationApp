namespace Domain.Abstractions;
public interface IGenericRepository<TEntity, TId> where TEntity : class
{
    Task<TEntity> CreateAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    IQueryable<TEntity> GetAll();
    Task<TEntity> GetByIdAsync(TId id);
}

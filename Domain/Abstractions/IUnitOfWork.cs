namespace Domain.Abstractions;
public interface IUnitOfWork
{
    void Commmit();
    Task CommitAsync(CancellationToken cancellation=default);
}

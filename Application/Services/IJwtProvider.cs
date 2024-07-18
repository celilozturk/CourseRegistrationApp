using Domain.Entities;

namespace Application.Services;
public interface IJwtProvider
{
    Task<string> CreateTokenAsync(AppUser user, CancellationToken cancellationToken);
}

using Domain.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class CandidateRepository : GenericRepository<Candidate, int>, ICandidateRepository
{
    public CandidateRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<IEnumerable<Candidate>> GetAllAsync()
    {
        return await _appDbContext.Candidates.ToListAsync();
    }
}

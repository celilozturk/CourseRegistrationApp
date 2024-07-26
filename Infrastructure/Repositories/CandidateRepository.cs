using Domain.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
    public async Task<bool> AnyAsync(Expression<Func<Candidate, bool>> expressions)
    {
      return await _appDbContext.Candidates.AnyAsync(expressions);
    }

    public async Task<Candidate> GetByEmailAsync(string email)
    {
        return await _appDbContext.Candidates.FirstOrDefaultAsync(c => c.Email == email);
    }
}

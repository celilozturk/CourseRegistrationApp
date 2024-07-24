using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repositories;
public interface ICandidateRepository:IGenericRepository<Candidate,int>
{
    Task<IEnumerable<Candidate>> GetAllAsync();

}

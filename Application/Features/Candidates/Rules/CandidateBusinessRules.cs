using Domain.Abstractions.Repositories;
using Domain.Common;
using Domain.Common.Exceptions.Base;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Candidates.Rules;
public class CandidateBusinessRules(ICandidateRepository candidateRepository):BaseBusinessRules
{
    
    public  async Task CheckIfEmailExist(string email)
    {
        if (await candidateRepository.AnyAsync(x=>x.Email==email))
        {
            throw new BusinessException("Email already exists!");
        }
    }
}

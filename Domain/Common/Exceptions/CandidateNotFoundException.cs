using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Exceptions.Base;
using Domain.Entities;

namespace Domain.Common.Exceptions;
public class CandidateNotFoundException : NotFoundException
{
    public CandidateNotFoundException(int candidateId) : base($"The candidate identifier {candidateId} was not found!")
    {
    }
}

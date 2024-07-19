using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Constants;
public static class StaticRoles
{
    public static List<AppRole> GetRoles()
    {
        //Refactor => getting roles from appsettings roles array
        List<string> roles = new()
        {
            "Admin",
            "Candidate",
            "Tutor"
        };

        return roles.Select(s=>new AppRole() { Name = s }).ToList();

    }
}

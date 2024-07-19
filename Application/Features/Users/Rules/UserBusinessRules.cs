using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.Common;
using Domain.Common.Exceptions.Base;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Users.Rules;
internal class UserBusinessRules(UserManager<AppUser> userManager, IUserRoleRepository userRoleRepository, IUnitOfWork unitOfWork) : BaseBusinessRules
{
    public void CheckIfUserNameExist(string userName)
    {
        if (userManager.Users.Any(u => u.UserName == userName))
        {
            throw new BusinessException("User Name already exists!");
        }
    }
    public  void CheckIfEmailExist(string email)
    {
        if (userManager.Users.Any(u => u.Email == email))
        {
            throw new BusinessException("Email already exists!");
        }
    }
    public void AddRoles(List<Guid> RoleIds, Guid userId)
    {
        var cancellationToken= new CancellationTokenSource();
        if (RoleIds.Any())
        {
            //List<AppUserRole> userRoles = new();
            foreach (var roleId in RoleIds)
            {
                AppUserRole role = new()
                {
                    RoleId = roleId,
                    UserId = userId
                };
                 userRoleRepository.CreateAsync(role, cancellationToken.Token).Wait();
            }
            unitOfWork.Commmit();
        }
    }
}

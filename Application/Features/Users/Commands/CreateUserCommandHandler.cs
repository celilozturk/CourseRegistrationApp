using Application.Features.Users.Rules;
using AutoMapper;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Users.Commands;




internal sealed class CreateUserCommandHandler(IUserRoleRepository userRoleRepository, IUnitOfWork unitOfWork, UserManager<AppUser> userManager, UserBusinessRules userBusinessRules, IMapper mapper) : IRequestHandler<CreateUserCommand, string>
{
    public Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
          userBusinessRules.CheckIfUserNameExist(request.UserName);
          userBusinessRules.CheckIfEmailExist(request.Email);
        AppUser user = mapper.Map<AppUser>(request);

        var result = userManager.CreateAsync(user, request.Password).Result;
        //if (!result.IsCompletedSuccessfully)
        //{
        //    return new CreateUserResponse() { Errors = result.Errors.Select(s => s.Description).ToList() };
        //}
        userBusinessRules.AddRoles(request.RoleIds, user.Id);
        return Task.FromResult("user was added successfully");
    }
}

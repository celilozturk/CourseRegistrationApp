using Application.Constants;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Roles.RoleSync;

internal sealed class RoleSyncCommandHandler(RoleManager<AppRole> roleManager) : IRequestHandler<RoleSyncCommand, RoleSyncResponse>
{
    public async Task<RoleSyncResponse> Handle(RoleSyncCommand request, CancellationToken cancellationToken)
    {
        List<AppRole> currentRoles = roleManager.Roles.ToList();
        List<AppRole> staticRoles = StaticRoles.GetRoles();

        foreach (AppRole role in currentRoles)
        {
            if (!staticRoles.Any(x => x.Name == role.Name))
            {
                await roleManager.DeleteAsync(role);
            }
        }

        foreach (AppRole role in staticRoles)
        {
            if (!currentRoles.Any(p => p.Name == role.Name))
            {
                await roleManager.CreateAsync(role);
            }
        }
        return new RoleSyncResponse() { Message="Sync is successful"};

    }
}
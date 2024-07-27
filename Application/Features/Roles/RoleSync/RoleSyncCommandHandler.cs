using Application.Constants;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Application.Features.Roles.RoleSync;

internal sealed class RoleSyncCommandHandler(RoleManager<AppRole> roleManager,IOptions<RoleOptions> roleOptions) : IRequestHandler<RoleSyncCommand, RoleSyncResponse>
{
    public async Task<RoleSyncResponse> Handle(RoleSyncCommand request, CancellationToken cancellationToken)
    {
        List<AppRole> currentRoles = roleManager.Roles.ToList();
        var appRoles = roleOptions.Value.Roles.Select(r => new AppRole { Name = r }).ToList();
        //List<AppRole> staticRoles = StaticRoles.GetRoles();
        

        foreach (AppRole role in currentRoles)
        {
            if (!appRoles.Any(x => x.Name == role.Name))
            {
                await roleManager.DeleteAsync(role);
            }
        }

        foreach (AppRole role in appRoles)
        {
            if (!currentRoles.Any(p => p.Name == role.Name))
            {
                await roleManager.CreateAsync(role);
            }
        }
        return new RoleSyncResponse() { Message="Sync is successful"};

    }
}
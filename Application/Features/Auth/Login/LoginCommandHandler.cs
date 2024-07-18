using Application.Services;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Domain.Common.Exceptions;


namespace Application.Features.Auth.Login;

internal sealed class LoginCommandHandler(UserManager<AppUser> userManager, IJwtProvider jwtProvider) : IRequestHandler<LoginCommand, LoginResponse>
{

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {

        AppUser? appUser = userManager.Users.FirstOrDefault(u => u.UserName == request.UserNameOrEmail || u.Email == request.UserNameOrEmail);

        if (appUser is null)
        {
            throw new UserNotFoundException(request.UserNameOrEmail);         

        }
        bool isPasswordCorrect = await userManager.CheckPasswordAsync(appUser, request.Password);
        if (isPasswordCorrect)
        {
            throw new LoginException();
        }
        string token = await jwtProvider.CreateTokenAsync(appUser,cancellationToken);
        LoginResponse response = new() { Token = token };
        return response;
    }
}
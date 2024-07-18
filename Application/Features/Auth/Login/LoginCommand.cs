using MediatR;
using Domain.Common.Exceptions.Base;


namespace Application.Features.Auth.Login;
public record LoginCommand(string UserNameOrEmail, string Password):IRequest<LoginResponse>;

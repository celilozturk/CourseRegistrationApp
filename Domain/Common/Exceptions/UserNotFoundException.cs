using Domain.Common.Exceptions.Base;

namespace Domain.Common.Exceptions;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(string? userNameOrEmail) : base($"{userNameOrEmail}  not found")
    {

    }
}

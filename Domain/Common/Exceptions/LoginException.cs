using Domain.Common.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Exceptions;
public class LoginException : BadRequestException
{
    public LoginException() : base("UserName and Email or Password is wrong ")
    {

    }
}

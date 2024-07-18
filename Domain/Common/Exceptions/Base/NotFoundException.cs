﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Exceptions.Base;
public class NotFoundException : Exception
{
    public NotFoundException(string? message) : base(message)
    {

    }
}

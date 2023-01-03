﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Domain.Exceptions;
public class DomainValidationException : Exception
{
    public DomainValidationException(string? message)
        : base(message)
    {
    }

    public DomainValidationException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}

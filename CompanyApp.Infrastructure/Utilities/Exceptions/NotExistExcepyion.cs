﻿namespace CompanyApp.Infrastructure.Utilities.Exceptions;

public class NotExistException : Exception
{
    public NotExistException(string message) : base(message) { }
}


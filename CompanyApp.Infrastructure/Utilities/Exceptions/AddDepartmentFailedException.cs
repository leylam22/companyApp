﻿namespace CompanyApp.Infrastructure.Utilities.Exceptions;

public class AddDepartmentFailedException : Exception
{
    public AddDepartmentFailedException(string message) : base(message) { }
}

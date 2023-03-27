namespace CompanyApp.Infrastructure.Utilities.Exceptions;

public class DublicateNameException : Exception
{
    public DublicateNameException(string message) : base(message) { }
}


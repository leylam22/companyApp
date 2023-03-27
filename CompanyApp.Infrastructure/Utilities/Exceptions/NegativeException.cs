namespace CompanyApp.Infrastructure.Utilities.Exceptions;

public class NegativeException : Exception
{
    public NegativeException(string message):base(message) { }
}

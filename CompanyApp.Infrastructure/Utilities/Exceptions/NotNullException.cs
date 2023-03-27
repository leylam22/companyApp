namespace CompanyApp.Infrastructure.Utilities.Exceptions;

public class NotNullException : Exception
{
    public NotNullException(string message) : base(message) { } 
}

namespace LongToShortUrl.Infrastructure.Exceptions;

public class InvalidUrlException : Exception
{
    public InvalidUrlException() : base() { }

    public InvalidUrlException(string message) : base(message) { }

    public InvalidUrlException(string message, Exception innerException) : base(message, innerException) { }
}


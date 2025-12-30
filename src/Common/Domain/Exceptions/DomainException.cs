namespace Common;

public class DomainException(string message, int statusCode = 400) : Exception(message)
{
    public int StatusCode => statusCode;
}

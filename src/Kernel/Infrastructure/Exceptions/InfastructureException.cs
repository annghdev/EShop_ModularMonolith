namespace Kernel.Infrastructure;

public class InfastructureException(string message, int errorCode = 500) : Exception(message)
{
    public int ErrorCode => errorCode;
}



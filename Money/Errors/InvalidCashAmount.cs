using Results;

namespace Money.Errors;

public class InvalidCashAmount : Exception, IError
{
    public InvalidCashAmount(decimal amount) : base($"{amount} is not a valid cash amount")
    {
    }

    public void Log(IErrorLogger logger) => logger.LogError(Message);
}
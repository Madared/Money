using Results;

namespace MoneyManagement.Errors;

public class InvalidPositiveDecimal : Exception, IError
{
    public InvalidPositiveDecimal(decimal value) : base($"{value} is not positive") {}
    public void Log(IErrorLogger logger) => logger.LogError(Message);
}
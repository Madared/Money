using Results;

namespace Money.Errors;

public class EmptyNameError : Exception, IError
{
    public EmptyNameError() : base("Name cannot be empty") {}
    public void Log(IErrorLogger logger) => logger.LogError(Message);
}
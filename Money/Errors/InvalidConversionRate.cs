using Results;

namespace Money.Errors;

public class InvalidConversionRate : Exception, IError
{
    public InvalidConversionRate(decimal rate) : base($"{rate} is not a valid conversion rate")
    {
    }

    public void Log(IErrorLogger logger)
    {
        throw new NotImplementedException();
    }
}
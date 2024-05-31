using ResultAndOption.Errors;
using ResultAndOption.Results;

namespace MoneyManagement.Errors;

public class InvalidConversionRate : Exception, IError
{
    public InvalidConversionRate(decimal rate) : base($"{rate} is not a valid conversion rate")
    { }
}
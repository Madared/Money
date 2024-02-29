using Money.Currency;
using Results;

namespace Money.Errors;

public class InvalidPrecisionSpecified : Exception, IError
{
    private string _value;
    private DecimalPrecisionValue _precision;
    
    public InvalidPrecisionSpecified(string value, DecimalPrecisionValue precision) :
        base($"The value {value} does not have the specified precision of {precision}")
    {
        _value = value;
        _precision = precision;
    }

    public void Log(IErrorLogger logger) =>
        logger.LogError($"The value {_value} does not have the specified precision of {_precision}");
}
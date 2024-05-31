using MoneyManagement.Currencies;
using ResultAndOption.Errors;
using ResultAndOption.Results;

namespace MoneyManagement.Errors;

public class InvalidPrecisionSpecified : Exception, IError
{
    private readonly string _value;
    private readonly DecimalPrecisionValue _precision;
    
    public InvalidPrecisionSpecified(string value, DecimalPrecisionValue precision) :
        base($"The value {value} does not have the specified precision of {precision}")
    {
        _value = value;
        _precision = precision;
    }
}
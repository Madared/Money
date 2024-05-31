using ResultAndOption.Errors;
using ResultAndOption.Results;

namespace MoneyManagement.Errors;

public class InvalidPositiveDecimal : Exception, IError
{
    public InvalidPositiveDecimal(decimal value) : base($"{value} is not positive") {}
}
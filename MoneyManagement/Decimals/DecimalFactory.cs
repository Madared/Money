using ResultAndOption.Errors;
using ResultAndOption.Results;
using ResultAndOption.Results.GenericResultExtensions;

namespace MoneyManagement.Decimals;

public static class DecimalFactory
{
    public static Result<INonNegativeDecimal> CreateNonNegative(decimal amount) => amount switch
    {
        0 => Result<INonNegativeDecimal>.Ok(new ZeroDecimal()),
        > 0 => PositiveDecimal.Create(amount).Map<PositiveDecimal, INonNegativeDecimal>(positive => positive),
        _ => Result<INonNegativeDecimal>.Fail(new UnknownError())
    };

    public static Result<INonPositiveDecimal> CreateNonPositive(decimal amount) => amount switch
    {
        0 => Result<INonPositiveDecimal>.Ok(new ZeroDecimal()),
        < 0 => NegativeDecimal.Create(amount).Map<NegativeDecimal, INonPositiveDecimal>(negative => negative),
        _ => Result<INonPositiveDecimal>.Fail(new UnknownError())
    };
}
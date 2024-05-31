using ResultAndOption.Errors;
using ResultAndOption.Results;

namespace MoneyManagement.Decimals;

/// <summary>
/// Interface intended to be added to all decimals which can guarantee they will always be positive.
/// Checks should be done with IsPositive static method of interface and not decimal.IsPositive as that would return true for 0(zero)
/// </summary>
public interface IPositiveDecimal : INonNegativeDecimal
{
    /// <summary>
    /// internal value of the positive decimal
    /// </summary>
    decimal Amount { get; }
    decimal INonNegativeDecimal.Amount => Amount;
    Result<ZeroDecimal> INonNegativeDecimal.AsZero() => Result<ZeroDecimal>.Fail(new UnknownError());
    Result<IPositiveDecimal> INonNegativeDecimal.AsPositive() => Result<IPositiveDecimal>.Ok(this);

    public static bool IsPositive(decimal value) => value > 0;
}
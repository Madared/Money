using Results;

namespace Money.Decimals;

/// <summary>
/// Interface intended to be added to all decimals which can guarantee they will always be positive.
/// Entities that implement this interface should always check for if the value passed is positive with the decimal.IsPositive method
/// </summary>
public interface IPositiveDecimal : INonNegativeDecimal
{
    /// <summary>
    /// internal value of the positive decimal
    /// </summary>
    decimal Amount { get; }

    Result<ZeroDecimal> INonNegativeDecimal.AsZero() => Result<ZeroDecimal>.Fail(new UnknownError());
    Result<IPositiveDecimal> INonNegativeDecimal.AsPositive() => Result<IPositiveDecimal>.Ok(this);
}
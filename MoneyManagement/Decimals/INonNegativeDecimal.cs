using ResultAndOption.Results;

namespace MoneyManagement.Decimals;

/// <summary>
/// Should be implemented by all entities that guarantee value is not negative.
/// Values should be checked with static method IsNonNegative.
/// </summary>
public interface INonNegativeDecimal {
    /// <summary>
    /// Internal value.
    /// </summary>
    decimal Amount { get; }

    /// <returns>Successful result if value is 0(zero) otherwise a failure result.</returns>
    public Result<ZeroDecimal> AsZero();
    /// <returns>Successful result if value is positive otherwise a failure result.</returns>
    public Result<IPositiveDecimal> AsPositive();

    /// <summary>
    /// Checks if value is 0(zero) or more.
    /// </summary>
    public static bool IsNonNegative(decimal value) => value >= 0;
}
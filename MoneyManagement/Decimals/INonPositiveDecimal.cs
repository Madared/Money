using ResultAndOption.Results;

namespace MoneyManagement.Decimals;

/// <summary>
/// Should be implemented by all entities that guarantee value is not positive.
/// Values should be checked with static method IsNonPositive.
/// </summary>
public interface INonPositiveDecimal {
    /// <summary>
    /// Internal value.
    /// </summary>
    decimal Amount { get; }
    /// <returns>Successful result if value is 0(zero) otherwise a failed result.</returns>
    Result<ZeroDecimal> AsZero();
    /// <returns>Successful result if value is negative otherwise a failed result.</returns>
    Result<NegativeDecimal> AsNegative();

    /// <summary>
    /// Checks if value is 0(zero) or less.
    /// </summary>
    public static bool IsNonPositive(decimal value) => value <= 0;
}
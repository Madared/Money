using Results;

namespace MoneyManagement.Decimals;

/// <summary>
/// Interface intended to be implemented by all entities which should be negative decimals,
/// All values should be checked with the static method INegativeDecimal.IsNegative to guarantee compliance.
/// </summary>
public interface INegativeDecimal : INonPositiveDecimal {
    /// <summary>
    /// internal value
    /// </summary>
    decimal Amount { get; }
    Result<ZeroDecimal> INonPositiveDecimal.AsZero() => Result<ZeroDecimal>.Fail(new UnknownError());
    Result<INegativeDecimal> INonPositiveDecimal.AsNegative() => Result<INegativeDecimal>.Ok(this);
    
    /// <summary>
    /// Checks if value is less than 0(zero).
    /// </summary>
    /// <param name="value">Value to check.</param>
    /// <returns>true if value is less than 0(zero)</returns>
    public static bool IsNegative(decimal value) => value < 0;
}
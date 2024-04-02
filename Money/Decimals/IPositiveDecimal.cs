namespace Money.Decimals;

/// <summary>
/// Interface intended to be added to all decimals which can guarantee they will always be positive
/// </summary>
public interface IPositiveDecimal : INonNegativeDecimal
{
    /// <summary>
    /// internal value of the positive decimal
    /// </summary>
    decimal Amount { get; }
}
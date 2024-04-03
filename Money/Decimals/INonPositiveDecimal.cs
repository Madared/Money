using Results;

namespace Money.Decimals;

public interface INonPositiveDecimal {
    decimal Amount { get; }
    Result<ZeroDecimal> AsZero();
    Result<INegativeDecimal> AsNegative();

    public static bool IsNonPositive(decimal value) => value <= 0;
}
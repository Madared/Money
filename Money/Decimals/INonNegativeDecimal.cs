using Results;

namespace Money.Decimals;

public interface INonNegativeDecimal {
    decimal Amount { get; }

    public Result<ZeroDecimal> AsZero();
    public Result<IPositiveDecimal> AsPositive();

    public static bool IsNonNegative(decimal value) => value >= 0;
}
using Results;

namespace Money.Decimals;

public interface INonPositiveDecimal {
    decimal Amount { get; }
    Result<ZeroDecimal> AsZero();
    Result<INegativeDecimal> AsNegative();
}
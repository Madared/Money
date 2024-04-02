using Results;

namespace Money.Decimals;

public interface INegativeDecimal : INonPositiveDecimal {
    decimal Amount { get; }
    Result<ZeroDecimal> INonPositiveDecimal.AsZero() => Result<ZeroDecimal>.Fail(new UnknownError());
    Result<INegativeDecimal> INonPositiveDecimal.AsNegative() => Result<INegativeDecimal>.Ok(this);
}
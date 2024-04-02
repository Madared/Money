using System.Security.Cryptography.X509Certificates;
using Results;

namespace Money.Decimals;

public record ZeroDecimal() : INonNegativeDecimal, INonPositiveDecimal {
    public decimal Amount => 0;
    Result<ZeroDecimal> INonPositiveDecimal.AsZero() => Result<ZeroDecimal>.Ok(this);

    public Result<INegativeDecimal> AsNegative() => Result<INegativeDecimal>.Fail(new UnknownError());

    Result<ZeroDecimal> INonNegativeDecimal.AsZero() => Result<ZeroDecimal>.Ok(this);

    public Result<IPositiveDecimal> AsPositive() => Result<IPositiveDecimal>.Fail(new UnknownError());

    public static implicit operator decimal(ZeroDecimal zero) => 0;
}
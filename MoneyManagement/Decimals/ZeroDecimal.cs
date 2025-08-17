using System.Security.Cryptography.X509Certificates;
using ResultAndOption.Errors;
using ResultAndOption.Results;

namespace MoneyManagement.Decimals;

public sealed record ZeroDecimal() : INonNegativeDecimal, INonPositiveDecimal {
    public decimal Amount => 0;
    Result<ZeroDecimal> INonPositiveDecimal.AsZero() => Result<ZeroDecimal>.Ok(this);
    public Result<NegativeDecimal> AsNegative() => Result<NegativeDecimal>.Fail(new UnknownError());
    Result<ZeroDecimal> INonNegativeDecimal.AsZero() => Result<ZeroDecimal>.Ok(this);
    public Result<PositiveDecimal> AsPositive() => Result<PositiveDecimal>.Fail(new UnknownError());
    public static implicit operator decimal(ZeroDecimal zero) => 0;
}
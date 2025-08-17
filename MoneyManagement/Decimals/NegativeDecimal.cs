using ResultAndOption.Errors;
using ResultAndOption.Results;

namespace MoneyManagement.Decimals;

public sealed record NegativeDecimal : INonPositiveDecimal
{
    public decimal Amount { get; }
    public Result<ZeroDecimal> AsZero() => Result<ZeroDecimal>.Fail(new UnknownError());
    public Result<NegativeDecimal> AsNegative() => Result<NegativeDecimal>.Ok(this);
    private NegativeDecimal(decimal value) {
        if (value.IsNonNegative()) throw new InvalidDataException();
        Amount = value;
    }
    
    public static Result<NegativeDecimal> Create(decimal value) => value.IsNegative()
        ? Result<NegativeDecimal>.Ok(new NegativeDecimal(value))
        : Result<NegativeDecimal>.Fail(new UnknownError());
    public static implicit operator decimal(NegativeDecimal negativeDecimal) => negativeDecimal.Amount;
}
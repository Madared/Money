using ResultAndOption.Errors;
using ResultAndOption.Results;

namespace MoneyManagement.Decimals;

public sealed record NegativeDecimal : INegativeDecimal
{
    public decimal Amount { get; }

    private NegativeDecimal(decimal value) {
        if (!INegativeDecimal.IsNegative(value)) throw new InvalidDataException();
        Amount = value;
    }

    public NegativeDecimal(INegativeDecimal negativeDecimal)
    {
        Amount = negativeDecimal.Amount;
    }

    public static Result<NegativeDecimal> Create(decimal value) => INegativeDecimal.IsNegative(value)
        ? Result<NegativeDecimal>.Ok(new NegativeDecimal(value))
        : Result<NegativeDecimal>.Fail(new UnknownError());
    public static implicit operator decimal(NegativeDecimal negativeDecimal) => negativeDecimal.Amount;
}
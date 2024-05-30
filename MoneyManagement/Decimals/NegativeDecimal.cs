using Results;

namespace MoneyManagement.Decimals;

public sealed record NegativeDecimal : INegativeDecimal
{
    public decimal Amount { get; }

    private NegativeDecimal(decimal value) {
        if (!INegativeDecimal.IsNegative(value)) throw new InvalidDataException();
        Amount = value;
    }

    public static Result<NegativeDecimal> Create(decimal value) => INegativeDecimal.IsNegative(value)
        ? Result<NegativeDecimal>.Ok(new NegativeDecimal(value))
        : Result<NegativeDecimal>.Fail(new UnknownError());
}
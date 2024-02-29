using Results;

namespace Money;

public record NegativeDecimal : INegativeDecimal
{
    public decimal Amount { get; }

    private NegativeDecimal(decimal value) => Amount = value >= 0
        ? throw new InvalidDataException()
        : value;

    public static Result<NegativeDecimal> Create(decimal value) => value >= 0
        ? Result<NegativeDecimal>.Fail(new UnknownError())
        : Result<NegativeDecimal>.Ok(new NegativeDecimal(value));
}
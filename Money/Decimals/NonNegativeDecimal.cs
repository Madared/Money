using Results;

namespace Money.Decimals;

public record NonNegativeDecimal : INonNegativeDecimal {
    public decimal Amount { get; }

    private NonNegativeDecimal(decimal amount) {
        if (!IsValid(amount)) throw new InvalidDataException();
        Amount = amount;
    }

    public static Result<NonNegativeDecimal> Create(decimal amount) => IsValid(amount)
        ? Result<NonNegativeDecimal>.Ok(new NonNegativeDecimal(amount))
        : Result<NonNegativeDecimal>.Fail(new UnknownError());

    public static INonNegativeDecimal Zero() => new ZeroDecimal();

    public static implicit operator decimal(NonNegativeDecimal nonNegative) => nonNegative.Amount;
    private static bool IsValid(decimal amount) => amount >= 0;
}
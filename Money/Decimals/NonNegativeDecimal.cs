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

    private static bool IsValid(decimal amount) => amount >= 0;
}
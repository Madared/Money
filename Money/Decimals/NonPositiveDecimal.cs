using Results;

namespace Money.Decimals;

public record NonPositiveDecimal : INonPositiveDecimal {
    public decimal Amount { get; }

    private NonPositiveDecimal(decimal amount) {
        if (!IsValid(amount)) throw new InvalidDataException();
        Amount = amount;
    }

    public static Result<NonPositiveDecimal> Create(decimal amount) => IsValid(amount)
        ? Result<NonPositiveDecimal>.Ok(new NonPositiveDecimal(amount))
        : Result<NonPositiveDecimal>.Fail(new UnknownError());

    public static implicit operator decimal(NonPositiveDecimal nonPositive) => nonPositive.Amount;
    private static bool IsValid(decimal amount) => amount <= 0;
}
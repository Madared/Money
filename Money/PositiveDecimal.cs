using Money.Errors;
using Results;

namespace Money;

public record PositiveDecimal : IPositiveDecimal
{
    public decimal Amount { get; }

    private static bool IsNegativeOrZero(decimal amount) => amount <= 0;
    private PositiveDecimal(decimal amount)
    {
        if (IsNegativeOrZero(amount)) throw new InvalidPositiveDecimal(amount);
        Amount = amount;
    }

    public static Result<PositiveDecimal> Create(decimal amount) => IsNegativeOrZero(amount)
        ? Result<PositiveDecimal>.Fail(new InvalidPositiveDecimal(amount))
        : Result<PositiveDecimal>.Ok(new PositiveDecimal(amount));

    public static PositiveDecimal One() => new PositiveDecimal(1);

    public IPositiveDecimal Times(IPositiveDecimal positiveDecimal) =>
        new PositiveDecimal(Amount * positiveDecimal.Amount);

    public IPositiveDecimal DivideBy(IPositiveDecimal positiveDecimal) =>
        new PositiveDecimal(Amount / positiveDecimal.Amount);

    public IPositiveDecimal Plus(IPositiveDecimal positiveDecimal) =>
        new PositiveDecimal(Amount + positiveDecimal.Amount);
}